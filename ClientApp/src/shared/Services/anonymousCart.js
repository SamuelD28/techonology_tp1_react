import Cart from './cart';
import ApiRequest from '../Api/apiRequest';

class AnonymousCart extends Cart {
    constructor() {
        super();

        this.Cart = [];
    }

    Add = (itemId, quantity) => {
        let item =  ApiRequest.GetItem(itemId);
        this.Cart.push({
            item: item,
            quantity: quantity,
        })
    }

    Remove = (itemId, quantity) => {
        throw new Error("not implemented");
    }

    Clear = () => {
        this.Cart = [];
    }

    Count = () => this.Cart.length;

    DistinctCount = () => this.Cart.reduce((a, b) => a.quantity + b.quantity);

    GetItems = () => Object.create(this.Cart);

    GetItem = (itemId) => {
        throw new Error("not implemented");
    }

    GetTotalCost = () => {
        throw new Error("not implemented");
    }
}

export default AnonymousCart;