import React from 'react';
import GlobalAppState from '../../shared/globalState';

/**
 * Represent the button to open the cart
 * */
class CartButton extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            itemsCount: props.itemsCount,
        };
        GlobalAppState.SubscribeStateChange(this.OnGlobalStateChanged);
    }

    /**
     * Handle the global state changed event. Change is own state depending of the global state
     * 
     * @param {any} state the new state
     */
    OnGlobalStateChanged = (state) => {
        let selfState = this.state;
        selfState.itemsCount = state.cart.Count();
        this.setState(selfState);
    }

    render() {
        let cartBadge;

        if (this.state.itemsCount !== 0) {
            cartBadge = <span className="badge badge-light btn-warning">{this.state.itemsCount}</span>;
        }

        return (
            <span id="cartAccess" className="cart-button notificable">
               <span className="oi oi-cart cart-icon"></span>{cartBadge}
            </span>
        );
    }
}

export default CartButton;