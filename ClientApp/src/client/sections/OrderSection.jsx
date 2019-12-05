import React from 'react';
import { Button, Modal, Row, ModalBody, ModalFooter, Container } from 'reactstrap';
import ApiRequest from '../../shared/api/apiRequest';
import GlobalAppState from '../../shared/globalState';
import { injectStripe, CardElement } from 'react-stripe-elements';

/**
 * The order section
 */
class OrderSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            error: '',
            isModalOpen: false,
            form: {
                ordersItems: props.cartItems
            }
        };
        console.log(this.state.form);

        this.apiRequest = new ApiRequest();
    }

    /**
    * @description Event handler for changes happening in an input
    *
    * @param {string} key Name of the input
    * @param {any} value Value of the input
    */
    HandleChange = (key, value) => {
        let state = this.state;
        state.form[key] = value;
        this.setState(state);
        console.log(state);
    }
    
    /**
    * @description Event handler for changes happening in an input
    */
    HandleSubmit = async (ev) => {
        // We don't want to let default form submission happen here, which would refresh the page.
        ev.preventDefault();

        // Use Elements to get a reference to the Card Element mounted somewhere
        // in your <Elements> tree. Elements will know how to find your Card Element
        // becase only one is allowed.
        // See our getElement documentation for more:
        // https://stripe.com/docs/stripe-js/reference#elements-get-element
        const cardElement = this.props.elements.getElement('card');

        // You can also use createToken to create tokens.
        // See our tokens documentation for more:}
        // https://stripe.com/docs/stripe-js/reference#stripe-create-token
        // With createToken, you will not need to pass in the reference to
        // the Element. It will be inferred automatically.
        const form = this.state.form;
        let { token } = await this.props.stripe.createToken({ type: 'card', name: form.customerName });
        if (token) {
            form.StripeToken = token.id;
            let order = await this.apiRequest.MakeOrder(form);
            if (order === null) {
                let state = this.state;
                state.error = 'An error occured. Please check your fileds'
                this.setState(state);
            }
            else {
                let state = GlobalAppState.state;
                await state.cart.Clear();
                GlobalAppState.setState(state);
            }
        }
    }

    DisplayError = () => {
        let view;
        if (this.state.error !== '') {
            view = <h1>{this.state.error}</h1>;
        }
        return view;
    }

    /**
     * Open and close the modal
     */
    ToggleModal = () => {
        let state = this.state;
        state.isModalOpen = !state.isModalOpen;
        this.setState(state);
    }

    render() {
        return (
            <div className="d-flex flex-grow-1">
                <Button onClick={this.ToggleModal} color="success" block>Order</Button>
                <Modal isOpen={this.state.isModalOpen} toggle={this.ToggleModal} size="lg">
                    <ModalBody className="bg-dark">
                        <form>
                            <div className="form-group">
                                <label htmlFor="customerName">Name</label>
                                <input
                                    type="texte"
                                    className="form-control"
                                    id="customerName"
                                    name="customerName"
                                    placeholder="Enter Name"
                                    onChange={(e) => this.HandleChange('customerName', e.target.value)}
                                    required />
                            </div>
                            <div className="form-group">
                                <label htmlFor="customerAdress">Adress</label>
                                <input
                                    type="texte"
                                    className="form-control"
                                    id="customerAdress"
                                    name="customerAdress"
                                    aria-describedby="customerAdressHelp"
                                    placeholder="Enter Adress"
                                    onChange={(e) => this.HandleChange('customerAdress', e.target.value)}
                                    required />
                                <small id="customerAdressHelp" className="form-text text-muted">Ex: 243 Howden Ave</small>
                            </div>
                            <div className="form-group">
                                <label htmlFor="customerPhoneNumber">Phone number</label>
                                <input
                                    type="tel"
                                    className="form-control"
                                    id="customerPhoneNumber"
                                    name="customerPhoneNumber"
                                    placeholder="Phone number"
                                    onChange={(e) => this.HandleChange('customerPhoneNumber', e.target.value)}
                                    required />
                            </div>
                            <CardElement style={{ base: { color: '#fff' } }} />
                        </form>
                    </ModalBody>
                    <ModalFooter className="bg-dark">
                        <Container>
                            <Row className="d-flex flex-row-reverse">
                                <Button onClick={this.ToggleModal} color="danger">Cancel</Button>
                                <Button onClick={this.HandleSubmit} className="mr-1" color="success">Confirm</Button>
                            </Row>
                        </Container>
                    </ModalFooter>
                </Modal>
            </div>
        )
    }
}

export default injectStripe(OrderSection);
