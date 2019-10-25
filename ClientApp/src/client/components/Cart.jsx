import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons'
import GlobalAppState from '../../shared/globalState';


class Cart extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            itemsCount: props.itemsCount,
        };
        GlobalAppState.SubscribeStateChange(this.OnCartChanged);
    }

    OnCartChanged = (state) => {
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
            <div id="cartAccess" className="mr-4 mb-4 align-items-center d-flex justify-content-center rounded-circle btn btn-warning notificable">
                <FontAwesomeIcon icon={faShoppingCart} /> {cartBadge}
            </div>
        );
    }
}

export default Cart;