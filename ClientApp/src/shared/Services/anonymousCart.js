import Cart from './cart'
import Ajax from '../ajax';
import Routes from '../routes';

class AnonymousCart extends Cart {
    constructor() {
        super();

        this.Cart = [];
    }

    Add = (itemId, quantity) => {
        Ajax.GetData(Routes.api.menuItems.get(itemId));
    }

    Remove = (itemId, quantity) => {
        throw new Error("not implemented");
    }

    Clear = () => {
        throw new Error("not implemented");
    }

    Count = () => {
        throw new Error("not implemented");
    }

    GetItems = () => {
        throw new Error("not implemented");
    }

    GetItem = (itemId) => {
        throw new Error("not implemented");
    }
}

export default AnonymousCart;