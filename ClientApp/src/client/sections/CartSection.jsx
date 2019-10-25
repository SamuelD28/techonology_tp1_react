import React from 'react';
import Cart from '../components/Cart';
import CartItem from '../components/CartItem';
import { Button, Modal, Row, ModalBody, ModalFooter, Container } from 'reactstrap';
import GlobalAppState from '../../shared/globalState';

class CartSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            isModalOpen: false,
            cart: GlobalAppState.state.cart
        };
        GlobalAppState.SubscribeStateChange(this.OnGlobalStateChanged);
    }

    OnGlobalStateChanged = (state) => {
        let selfState = this.state;
        selfState.cart = state.cart;
        this.setState(selfState);
    }

    ToggleModal = () => {
        let state = this.state;
        state.isModalOpen = !state.isModalOpen;
        this.setState(state);
    }

    DisplayCartItems = () => {
        let view = <h1>Your cart is empty</h1>;
        if (this.state.cart.Count() !== 0) {
            view = this.state.cart.GetItems().map((cartItems, index) => (
                <CartItem
                    key={index}
                    layout="stacked"
                    size={12}
                    name={cartItems.item.name}
                    img={cartItems.item.image.file}
                    isBase64={true}
                    description={cartItems.item.description}
                    price={cartItems.item.price}
                    id={cartItems.item.id}
                    quantity={cartItems.quantity}
                />

            ));
        }
        return view;
    }

    DisplayFooter = () => {
        let view;
        if (this.state.cart.Count() !== 0) {
            view = <ModalFooter className="bg-dark">
                <Container>
                    <Row className="d-flex flex-row-reverse">
                        <h2>Total : <span>${this.state.cart.GetTotalCost()}</span></h2>
                    </Row>
                    <Row>
                        <Button color="success" block>Order</Button>
                    </Row>
                </Container>
            </ModalFooter>;
        }
        return view;
    }

    render() {
        return (
            <div>
                <span onClick={this.ToggleModal}><Cart itemsCount={0} /></span>
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
