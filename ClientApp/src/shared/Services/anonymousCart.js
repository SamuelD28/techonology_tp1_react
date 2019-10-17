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
        console.log('adding: item(' + itemId + ') x quantity(' + quantity + ')');
        let item = await this.ApiRequest.GetItem(itemId);
        let index = ArrayExt.Find(this.Cart, (itemCart) => itemCart.item.id == itemId);
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
        throw new Error("not implemented");
    }

    Clear = () => {
        this.Cart = [];
    }

    Count = () => this.Cart.length;

    DistinctCount = () => {
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
        throw new Error("not implemented");
    }
}

export default AnonymousCart;