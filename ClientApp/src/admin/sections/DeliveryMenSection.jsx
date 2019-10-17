import React from 'react';
import Ajax from '../../shared/ajax';
import DeliveryMenDetail from '../components/DeliveryMenDetail';
import { Table, Modal, ModalBody, ModalHeader } from 'reactstrap';


class DeliveryMenSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = { selectedDeliveryMan: null };
        this.GetDeliveryMen();
    }

    GetDeliveryMen = async () => {
        let results = await Ajax.GetData("/api/deliverymen");
        if (results.statusCode >= 200 || results.statusCode <= 300) {
            this.setState({ deliveryMen: results.value });
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
                <tr style={{ cursor: "pointer" }}
                    key={deliveryMan.id}
                    onClick={() => this.ToggleModal(deliveryMan)}>
                    <td>{deliveryMan.name}</td>
                    <td>{deliveryMan.phone}</td>
                    <td>{deliveryMan.isEmployed ? "Oui" : "Non"}</td>
                </tr>
            ));
        }
    }

    RenderModal = () => {

        let deliveryMan = this.state.selectedDeliveryMan;

        return (
            <Modal
                isOpen={deliveryMan !== null}
                toggle={() => this.ToggleModal(null)}>
                <ModalHeader
                    className="black-modal"
                    toggle={() => this.ToggleModal(null)}>
                    {deliveryMan && deliveryMan.name}
                </ModalHeader>
                <ModalBody className="black-modal">
                    <DeliveryMenDetail deliveryMan={deliveryMan} />
                </ModalBody>
            </Modal>
        );
    }

    render() {
        return (
            <section>
                <h1>Les livreurs</h1>
                <Table dark hover>
                    <thead>
                        <tr>
                            <th>Nom</th>
                            <th>Téléphone</th>
                            <th>Est employé</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.DisplayDeliveryMen()}
                    </tbody>
                </Table>
                {this.RenderModal()}
            </section>
        );
    }
}

export default DeliveryMenSection;