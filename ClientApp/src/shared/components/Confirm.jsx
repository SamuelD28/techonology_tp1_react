import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class Confirm extends Component {

    constructor(props) {
        super(props);
        this.state = { modal: false };
    }

    Toggle = () => this.setState({ modal: !this.state.modal });

    ExecuteConfirmedAction = (confirmed) => {
        if (confirmed) {
            this.props.successAction();
            this.setState({ modal: false });
        } else {
            this.setState({ modal: false });
        }
    }

    render() {
        return (
            <div>
                <span onClick={this.Toggle}>
                    {this.props.trigger}
                </span>
                <Modal
                    centered
                    size="sm"
                    fade={false}
                    isOpen={this.state.modal}
                    toggle={this.Toggle}>
                    <ModalBody className="bg-dark">
                        <h3 className="text-primary">Confirmer</h3>
                        <p>{this.props.message}</p>
                        <div class="float-right">
                            <Button
                                className="mr-2"
                                color="danger"
                                onClick={() => this.ExecuteConfirmedAction(false)}>
                                Non
                            </Button>
                            <Button
                                color="success"
                                onClick={() => this.ExecuteConfirmedAction(true)}>
                                Oui
                            </Button>
                        </div>
                        </ModalBody>
                </Modal>
            </div>
        )
    }
};

export default Confirm;