import React from 'react';
import { Button, Modal, Row, ModalBody, ModalFooter, Container } from 'reactstrap';
import ApiRequest from '../../shared/api/apiRequest';
import { useHistory } from "react-router-dom";

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
    HandleSubmit = async () => {
        let order = await this.apiRequest.MakeOrder(this.state.form);
        if (order === null) {
            let state = this.state;
            state.error = 'An error occured. Please check your fileds'
            this.setState(state);
        }
        else {
            let history = useHistory();
            history.push("/");
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
                            {this.DisplayError()}
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
        );
    }
}

export default OrderSection;
