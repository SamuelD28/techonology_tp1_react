import React, { Component } from 'react';
import { Button, Modal, ModalBody } from 'reactstrap';
import Ajax from '../../shared/ajax';
import List from '../../shared/components/List';

/**
 * @description Statefull component that create a confirm modal.
 * 
 **/
class ImagePicker extends Component {

    /**
     * @description Constructor. Initiate the state.
     * 
     * @param {any} props
     */
    constructor(props) {
        super(props);
        this.state = { modal: false, images : [] };
    }

    async componentDidMount(){
        this.GetImages();
    }

    GetImages = async() => {

        let results = await Ajax.GetData("https://servefile.herokuapp.com/images/info");

        if(results){
            this.setState({images : results});
        }
    }

    /**
     *  @description Method that open and close the modal.
     *  
     **/
    Toggle = () => this.setState({ modal: !this.state.modal });

    render() {
        return (
            <div>
                <span onClick={this.Toggle}>
                    {this.props.children}
                </span>
                <Modal
                    centered
                    fade={false}
                    isOpen={this.state.modal}
                    toggle={this.Toggle}>
                    <ModalBody className="bg-dark">
                        <List
                            colSize={3}
                            className="no-gutters"
                            records={this.state.images}>
                            {image => (
                                <img src={image.url} />
                            )}
                        </List>
                    </ModalBody>
                </Modal>
            </div>
        )
    }
};

export default ImagePicker;