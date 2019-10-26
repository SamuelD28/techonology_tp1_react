import React from 'react';
import { Button, Modal, Row, ModalBody, ModalFooter, Container } from 'reactstrap';

/**
 * The order section
 * */
class OrderSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            isModalOpen: false,
        };
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
                                <input type="texte" className="form-control" id="customerName" name="customerName" placeholder="Enter Name" required/>
                            </div>
                            <div className="form-group">
                                <label htmlFor="customerAdress">Adress</label>
                                <input type="texte" className="form-control" id="customerAdress" name="customerAdress" aria-describedby="customerAdressHelp" placeholder="Enter Adress" required/>
                                <small id="customerAdressHelp" className="form-text text-muted">Ex: 243 Howden Ave</small>
                            </div>
                            <div className="form-group">
                                <label htmlFor="customerPhoneNumber">Phone number</label>
                                <input type="tel" className="form-control" id="customerPhoneNumber" name="customerPhoneNumber" placeholder="Phone number" required/>
                            </div>
                        </form>
                    </ModalBody>
                    <ModalFooter className="bg-dark">
                        <Container>
                            <Row className="d-flex flex-row-reverse">
                                <Button onClick={this.ToggleModal} color="danger">Cancel</Button>
                                <Button className="mr-1" color="success">Confirm</Button>
                            </Row>
                        </Container>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
}

export default OrderSection;
