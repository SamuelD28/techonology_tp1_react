import React from 'react';
import Ajax from '../../shared/ajax';
import DeliveryMenDetail from '../components/DeliveryMenDetail';
import { Col, Badge, Button, Modal, ModalBody, ModalHeader, Card, CardTitle, CardBody, Row, CardSubtitle } from 'reactstrap';


class DeliveryMenSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = { selectedDeliveryMan: null };
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
            selectedDeliveryMan: deliveryMan
        });
    }

    DisplayDeliveryMen = () => {
        if (this.state.deliveryMen) {
            return this.state.deliveryMen.map((deliveryMan) => (
                <Col
                    md="4"
                    key={deliveryMan.id}>
                    >
                    <Card
                        className="bg-dark m-2 p-4 text-center"
                        key={deliveryMan.id}>
                        <img
                            className="mx-auto"
                            width="50%"
                            src="/images/female_avatar.svg"
                            alt="User Profile picture" />
                        <CardBody>
                            <CardTitle>{deliveryMan.name}</CardTitle>
                            <CardSubtitle>{deliveryMan.phone}</CardSubtitle>
                            <Button
                                className="mt-4"
                                color="primary"
                                onClick={() => this.ToggleModal(deliveryMan)}
                            >Détails
                            </Button>
                        </CardBody>
                    </Card>
                </Col>
            ));
        }
    }

    RenderModal = () => {

        let deliveryMan = this.state.selectedDeliveryMan;

        return (
            <Modal
                isOpen={deliveryMan !== null}
                toggle={() => this.ToggleModal(null)}>
                <ModalBody className="black-modal">
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
                    <button className="btn btn-primary">Ajouter</button>
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