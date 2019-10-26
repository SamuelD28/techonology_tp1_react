import Cart from './cart';
import ApiRequest from '../api/apiRequest';
import { Array as ArrayExt } from '../utility';

/**
 * The cart of someone that is not connected
 */
class AnonymousCart extends Cart {
    constructor() {
        super();

        this.ApiRequest = new ApiRequest();
        this.Cart = [];
    }

    /**
     * @inheritdoc 
     */
    Add = async (itemId, quantity) => {
        let item = await this.ApiRequest.GetItem(itemId);
        console.log(item);
        console.log('adding: item(' + item.name + ') x quantity(' + quantity + ')');
        let index = ArrayExt.Find(this.Cart, (itemCart) => itemCart.item.id === itemId);
        console.log(item);
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

    /**
    * @inheritdoc
    */
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

    /**
    * @inheritdoc
    */
    Clear = async () => {
        this.Cart = [];
    }

    /**
    * @inheritdoc
    */
    DistinctCount = () => this.Cart.length;

    /**
    * @inheritdoc
    */
    Count = () => {
        if (this.Cart.length === 0) {
            return 0;
        }
        else {
            return this.Cart.reduce((a, b) => a + b.quantity, 0);
        }
    }

    /**
    * @inheritdoc
    */
    GetItems = () => Object.create(this.Cart);

    /**
    * @inheritdoc
    */
    GetItem = (itemId) => {
        throw new Error("not implemented");
    }

    /**
    * @inheritdoc
    */
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