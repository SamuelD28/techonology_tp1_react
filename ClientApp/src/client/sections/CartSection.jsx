import React from 'react';
import Cart from '../components/Cart';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class CartSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = { isModalOpen: false };
    }



    ToggleModal = () => {
        let state = this.state;
        state.isModalOpen = !state.isModalOpen;
        this.setState(state);
    }

    render() { 
        return (
            <div>
                <span onClick={this.ToggleModal}><Cart itemsCount={0} /></span>
                <Modal isOpen={this.state.isModalOpen} toggle={this.ToggleModal}>
                    <ModalBody className="bg-dark">
                        <form action="/action_page.php" className="bg-dark">
                            <div className="form-group">
                                <label htmlFor="email">Email address:</label>
                                <input type="email" className="form-control" id="email" />
                            </div>
                            <div className="form-group">
                                <label htmlFor="pwd">Password:</label>
                                <input type="password" className="form-control" id="pwd" />
                            </div>
                            <div className="checkbox">
                                <label><input type="checkbox" /> Remember me</label>
                            </div>
                            <button type="submit" className="btn btn-default">Submit</button>
                        </form>
                    </ModalBody>
                </Modal>
            </div>
        );
    }
}

export default CartSection;
