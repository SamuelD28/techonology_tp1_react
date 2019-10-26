var Converter = {};

/**
 * Convert an integer into a category
 * 
 * @param {int} number category's number
 * @returns {string} category's name
 */
Converter.IntToCategory = (number) => ['Pizza', 'Drink', 'Dessert', 'Other'][number];

export default Converter;
