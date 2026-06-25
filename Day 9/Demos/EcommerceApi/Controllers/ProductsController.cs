using Microsoft.AspNetCore.Mvc;
using EcommerceApi.DTOs;
using EcommerceApi.Repositories.Interfaces;
using EcommerceApi.Models;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// Get all products.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
    {
        var products = await _productRepository.GetAllAsync();
        var productDtos = products.Select(p => MapToResponseDto(p)).ToList();
        return Ok(productDtos);
    }

    /// <summary>
    /// Get a product by ID.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponseDto>> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found." });

        return Ok(MapToResponseDto(product));
    }

    /// <summary>
    /// Create a new product.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductResponseDto>> Create([FromBody] ProductCreateDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = new Product
        {
            ProductName = createDto.ProductName,
            Description = createDto.Description,
            Price = createDto.Price,
            StockQuantity = createDto.StockQuantity,
            CategoryId = createDto.CategoryId
        };

        var createdProduct = await _productRepository.CreateAsync(product);
        var responseDto = MapToResponseDto(createdProduct);

        return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductId }, responseDto);
    }

    /// <summary>
    /// Update an existing product.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductResponseDto>> Update(int id, [FromBody] ProductUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found." });

        product.ProductName = updateDto.ProductName;
        product.Description = updateDto.Description;
        product.Price = updateDto.Price;
        product.StockQuantity = updateDto.StockQuantity;
        product.CategoryId = updateDto.CategoryId;

        var updatedProduct = await _productRepository.UpdateAsync(product);
        return Ok(MapToResponseDto(updatedProduct));
    }

    /// <summary>
    /// Delete a product by ID.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var exists = await _productRepository.ExistsAsync(id);

        if (!exists)
            return NotFound(new { message = $"Product with ID {id} not found." });

        await _productRepository.DeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Maps a Product entity to ProductResponseDto.
    /// </summary>
    private static ProductResponseDto MapToResponseDto(Product product)
    {
        return new ProductResponseDto
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.CategoryName ?? "Unknown"
        };
    }
}
