import React from 'react';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons'

class Cart extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div id="cartAccess" className="mr-4 mb-4 align-items-center d-flex justify-content-center rounded-circle btn btn-warning">
                <FontAwesomeIcon icon={faShoppingCart} />
            </div>
        )
    }
}

export default Cart;
