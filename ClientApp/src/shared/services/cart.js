/**
 * Base Class for cart
 * */
class Cart {
    /**
    * Add an item asynchronously into the cart
    *
    * @param {int} itemId item's id
    * @param {int} quantity quantity to add
    */
    Add = async (itemId, quantity) => {
        throw new Error("not implemented");
    }

    /**
    * Remove an item asynchronously from the cart
    *
    * @param {int} itemId item's id
    * @param {int} quantity quantity to remove
    */
    Remove = (itemId, quantity) => {
        throw new Error("not implemented");
    }

    /**
    * Clear the cart asynchronously
    */
    Clear = async () => {
        throw new Error("not implemented");
    }

    /**
    * Give the total count of the cart. Each item x their quantity
    */
    Count = () => {
        throw new Error("not implemented");
    }

    /**
    * Give the distinct count of the cart. Count of distinct items
    */
    DistinctCount = () => {
        throw new Error("not implemented");
    }

    /**
     * Get all items asynchronously
     *
     * @returns {Array}
     */
    GetItems = async () => {
        throw new Error("not implemented");
    }

    /**
    * Get an item asynchronously
    *
    * @param {int} itemId Item's id
    * @returns {any|null} items
    */
    GetItem = (itemId) => {
        throw new Error("not implemented");
    }

    /**
    * Get cart's total cost
    *
    * @returns {double}
    */
    GetTotalCost = () => {
        throw new Error("not implemented");
    }
}

export default Cart;