using Microsoft.AspNetCore.Mvc;
using EcommerceApi.DTOs;
using EcommerceApi.Services.Interfaces;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAll()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponseDto>> GetById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound(new { message = $"Category with ID {id} not found." });

        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryResponseDto>> Create([FromBody] CategoryCreateDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdCategory = await _categoryService.CreateCategoryAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = createdCategory.CategoryId }, createdCategory);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponseDto>> Update(int id, [FromBody] CategoryUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != updateDto.CategoryId)
            return BadRequest(new { message = "Route id does not match category id in body." });

        try
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateDto);
            return Ok(updatedCategory);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { message = $"Category with ID {id} not found." });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _categoryService.DeleteCategoryAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Category with ID {id} not found." });

        return NoContent();
    }
}
