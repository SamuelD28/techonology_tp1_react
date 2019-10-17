import React from 'react';
import Ajax from '../../shared/ajax';
import DeliveryMenDetail from '../components/DeliveryMenDetail';
import { Col, Modal, ModalBody, Row, Button } from 'reactstrap';
import DeliveryManCard from '../components/DeliveryMenCard';

class DeliveryMenSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = { modal: false, selectedDeliveryMan : null };
        this.GetDeliveryMen();
    }

    GetDeliveryMen = async () => {
        let results = await Ajax.GetData("/api/deliverymen");
        if (results.statusCode >= 200 || results.statusCode <= 300) {

            let data = results.value.filter((d) => d.isEmployed);

            this.setState({ deliveryMen: data });
            console.log(this.state);
        }
    }

    ToggleModal = (deliveryMan) => {
        this.setState({
            modal: !this.state.modal,
            selectedDeliveryMan: deliveryMan
        });
    }

    DisplayDeliveryMen = () => {
        if (this.state.deliveryMen) {
            return this.state.deliveryMen.map((deliveryMan) => (
                <Col
                    md="4"
                    key={deliveryMan.id}>
                    <DeliveryManCard
                        deliveryMan={deliveryMan}
                        showDetails={() => this.ToggleModal(deliveryMan)}
                    />
                </Col>
            ));
        }
    }

    RenderModal = () => {

        let deliveryMan = this.state.selectedDeliveryMan;
        return (
            <Modal
                centered
                isOpen={this.state.modal}
                toggle={this.ToggleModal}>
                <ModalBody className="bg-dark">
                    <DeliveryMenDetail
                        ToggleModal={this.ToggleModal}
                        Refresh={this.GetDeliveryMen}
                        deliveryMan={deliveryMan} />
                </ModalBody>
            </Modal>
        );
    }

    render() {
        return (
            <section className="bg-secondary p-4 rounded">
                <h1 className="d-flex justify-content-between">Les livreurs
                    <Button onClick={() => this.ToggleModal({})} color="primary">Ajouter</Button>
                </h1>
                <Row noGutters>
                    {this.DisplayDeliveryMen()}
                </Row>
                {this.RenderModal()}
            </section>
        );
    }
}

export default DeliveryMenSection;