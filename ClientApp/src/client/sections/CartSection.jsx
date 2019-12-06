import React from 'react';
import OrderSection from '../sections/OrderSection';
import OrderSectionConnected from '../sections/OrderSectionConnected';
import CartButton from '../components/CartButton';
import CartItem from '../components/CartItem';
import { Modal, Row, ModalBody, ModalFooter, Container } from 'reactstrap';
import GlobalAppState from '../../shared/globalState';
import { Elements } from 'react-stripe-elements';

/**
 * The cart section with his button
 * */
class CartSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            isModalOpen: false,
            cart: GlobalAppState.state.cart
        };
        GlobalAppState.SubscribeStateChange(this.OnGlobalStateChanged);
    }

    mapCartItems = (cartItem, index) => {
        return {
            MenuItemId: cartItem.item.id,
            Quantity: cartItem.quantity
        }
    }

    /**
    * Handle the global state changed event. Change is own state depending of the global state
    *
    * @param {any} state the new state
    */
    OnGlobalStateChanged = (state) => {
        let selfState = this.state;
        selfState.cart = state.cart;
        this.setState(selfState);
    }

    /**
     * Open and close the modal
     */
    ToggleModal = () => {
        let state = this.state;
        state.isModalOpen = !state.isModalOpen;
        this.setState(state);
    }

    /**
     * Display all cartItems or an empty message
     */
    DisplayCartItems = () => {
        let view = <h1>Your cart is empty</h1>;
        console.log(this.state.cart.DistinctCount());
        if (this.state.cart.Count() !== 0) {
            view = this.state.cart.GetItems().map((cartItems, index) => (
                <CartItem
                    key={index}
                    layout="stacked"
                    size={12}
                    name={cartItems.item.name}
                    img={cartItems.item.imageUrl}
                    isBase64={false}
                    description={cartItems.item.description}
                    price={cartItems.item.price}
                    id={cartItems.item.id}
                    quantity={cartItems.quantity}
                />

            ));
        }
        return view;
    }

    /**
     * Display the price and an order button or nothing if the cart is empty
     */
    DisplayFooter = () => {
        let view;
        let Section = this.props.user ? OrderSectionConnected : OrderSection;
        if (this.state.cart.Count() !== 0) {
            view = <ModalFooter className="bg-dark">
                <Container>
                    <Row className="d-flex flex-row-reverse">
                        <h2>Total : <span>${this.state.cart.GetTotalCost()}</span></h2>
                    </Row>
                    <Row>
                        <Elements>
                            <Section user={this.props.user} cartItems={this.state.cart.GetItems().map(this.mapCartItems)} />
                        </Elements>
                        
                    </Row>
                </Container>
            </ModalFooter>;
        }
        return view;
    }

    render() {
        return (
            <div>
                <span onClick={this.ToggleModal}><CartButton itemsCount={0} /></span>
                <Modal isOpen={this.state.isModalOpen} toggle={this.ToggleModal} size="lg">
                    <ModalBody className="bg-dark">
                        {this.DisplayCartItems()}
                    </ModalBody>
                    {this.DisplayFooter()}
                </Modal>
            </div>
        );
    }
}

export default CartSection;
