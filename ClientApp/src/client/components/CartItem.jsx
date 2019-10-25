import React from 'react';
import GlobalAppState from '../../shared/globalState';
import { Col, Button } from 'reactstrap';

function ChooseLayout(props) {
    return <CartItemStacked
        id={props.id}
        name={props.name}
        description={props.description}
        price={props.price}
        img={props.img}
        isBase64={props.isBase64}
        quantity={props.quantity}
    />
};

const CartItemStacked = props => (
    <div className="services-wrap d-flex pb-1">
        <div className="img col-md-4" style={StyleImage(props.isBase64, props.img)}></div>
        <div className="text p-4 col-md-8">
            <h3>{props.name}</h3>
            <p>{props.description}</p>
            <p className="price">
                <span>${props.price}({props.quantity}) = ${props.quantity * props.price}</span>
            </p>
            <div className="row">
                <div className="col-4 pr-2 pl-2">
                    <Button color="success" onClick={() => AddItemToCart(props.id, 1)} block>Add</Button>
                </div>
                <div className="col-4 pr-2 pl-2">
                    <Button color="danger" onClick={() => RemoveItemFromCart(props.id, 1)} block>Remove</Button>
                </div>
                <div className="col-4 pr-2 pl-2">
                    <Button color="danger" onClick={() => RemoveItemFromCart(props.id, props.quantity)} block>Clear</Button>
                </div>

            </div>
        </div>
    </div>
);

/**
 * Set the sytle of an image based on is source
 * 
 * @param {any} isBase64 the source is a base 64 encoded string
 * @param {any} img source
 */
const StyleImage = (isBase64, img) => {
    if (!isBase64)
        return { backgroundImage: `url(${img})` };
    else {
        return { backgroundImage: `url(data:image/png;base64,${img})` };
    }
};

/**
 * Add an item to the cart
 * 
 * @param {any} id item's id
 * @param {any} quantity item's quantity
 */
const AddItemToCart = async (id, quantity) => {
    let state = GlobalAppState.state;
    await state.cart.Add(id, quantity);
    GlobalAppState.setState(state);
}

/**
 * Remove an item from the cart
 * 
 * @param {any} id item's id
 * @param {any} quantity item's quantity
 */
const RemoveItemFromCart = async (id, quantity) => {
    let state = GlobalAppState.state;
    await state.cart.Remove(id, quantity);
    GlobalAppState.setState(state);
}


const CartItem = props => (
    <Col md={props.size}>
        {ChooseLayout(props)}
    </Col>
);

export default CartItem;