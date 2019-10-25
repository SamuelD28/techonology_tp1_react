import Cart from './cart';
import ApiRequest from '../api/apiRequest';
import { Array as ArrayExt } from '../utility';

class AnonymousCart extends Cart {
    constructor() {
        super();

        this.ApiRequest = new ApiRequest();
        this.Cart = [];
    }

    Add = async (itemId, quantity) => {
        let item = await this.ApiRequest.GetItem(itemId);
        console.log('adding: item(' + item.name + ') x quantity(' + quantity + ')');
        let index = ArrayExt.Find(this.Cart, (itemCart) => itemCart.item.id === itemId);
        if (index !== -1) {
            this.Cart[index].quantity++;
        }
        else {
            this.Cart.push({
                item: item,
                quantity: quantity,
            })
        }
    }

    Remove = (itemId, quantity) => {
        let index = ArrayExt.Find(this.Cart, (itemCart) => itemCart.item.id === itemId);
        if (index !== -1) {
            let cartItem = this.Cart[index];
            if (cartItem.quantity > quantity) {
                cartItem.quantity -= quantity;
            }
            else {
                ArrayExt.RemoveAtUnOrdered(this.Cart, index);
            }
        }
    }

    Clear = async () => {
        this.Cart = [];
    }

    DistinctCount = () => this.Cart.length;

    Count = () => {
        if (this.Cart.length === 0) {
            return 0;
        }
        else {
            return this.Cart.reduce((a, b) => a + b.quantity, 0);
        }
    }

    GetItems = () => Object.create(this.Cart);

    GetItem = (itemId) => {
        throw new Error("not implemented");
    }

    GetTotalCost = () => {
        if (this.Cart.length === 0) {
            return (0).toFixed(2);
        }
        else {
            return this.Cart.reduce((a, b) => a + b.item.price * b.quantity, 0).toFixed(2);
        }
    }
}

export default AnonymousCart;