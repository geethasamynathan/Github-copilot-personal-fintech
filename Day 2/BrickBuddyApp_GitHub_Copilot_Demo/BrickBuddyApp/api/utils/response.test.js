const { responseUtilityFunction } = require('./response'); // Adjust the import based on your actual function

test('should return expected response', () => {
    const result = responseUtilityFunction();
    expect(result).toEqual(expectedValue); // Replace expectedValue with the actual expected output
});