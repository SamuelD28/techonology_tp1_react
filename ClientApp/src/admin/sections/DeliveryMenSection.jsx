import React from 'react';
import Ajax from '../../shared/ajax';
import DeliveryMenDetail from '../components/DeliveryMenDetail';
import { Col, Modal, ModalBody, Row, Button } from 'reactstrap';
import DeliveryManCard from '../components/DeliveryMenCard';

class DeliveryMenSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            modal: false,
            selectedDeliveryMan: null,
            previousQuery: null,
            currentQuery: "/api/deliverymen?start=0&end=6",
            nextQuery: null,
            loading: false,
            operationLatency : 1000
        };
    }

    async componentDidMount() {
        await this.ShowLoading();
        this.GetDeliveryMen();
    }

    ShowLoading = async() => {
        await this.setState({ loading: true });
        await new Promise(resolve => setTimeout(resolve, this.state.operationLatency));
    }

    GetDeliveryMen = async () => {
        let results = await Ajax.GetData(this.state.currentQuery);

        if (results.statusCode >= 200 || results.statusCode < 300) {

            let data = results.value.data;
            this.setState({
                deliveryMen: data,
                nextQuery: results.value.next,
                previousQuery: results.value.previous
            });
        }

        this.setState({ loading: false });
    }

    RefreshCurrentDeliveryMen = async (query) => {
        await this.setState({ currentQuery: query });
        this.GetDeliveryMen();
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
                        className="h-100"
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
                        Done={this.ToggleModal}
                        Refresh={this.GetDeliveryMen}
                        deliveryMan={deliveryMan} />
                </ModalBody>
            </Modal>
        );
    }

    DisplayPaginationButtons = () => {
        return (
            <div className="d-flex">
                <Button
                    className="mr-auto"
                    hidden={this.state.previousQuery === null}
                    onClick={() => this.RefreshCurrentDeliveryMen(this.state.previousQuery)}
                    color="primary">
                    <span className="oi mr-2 oi-arrow-left"></span>
                    Précédent
                </Button>
                <Button
                    className="ml-auto"
                    hidden={this.state.nextQuery === null}
                    onClick={() => this.RefreshCurrentDeliveryMen(this.state.nextQuery)}
                    color="primary">
                    Suivant
                    <span className="oi ml-2 oi-arrow-right"></span>
                </Button>
            </div>
        );
    }

    DisplayCurrentPagination = () => {
        let regex = /[0-9]+/gm;
        let res = this.state.currentQuery.match(regex);
        return <div className="text-white">{res[0]} à {res[1]}</div>
    }

    DisplayPagination = () => {
        return (
            <div className="text-center p-4">
                {this.DisplayCurrentPagination()}
                {this.DisplayPaginationButtons()}
            </div>
        );
    }

    DisplayComponentState = () => {
        if (!this.state.loading) {
            return (
                <div>
                    <Row noGutters>
                        {this.DisplayDeliveryMen()}
                    </Row>
                    {this.DisplayPagination()}
                </div>
            );
        } else {
            return (
                <div className="loader">Loading...</div>
            );
        }
    }

    render() {
        return (
            <section className="section-bg rounded-lg">
                <div className="d-flex justify-content-between align-items-center p-4">
                    <h1 className="section-title">Les livreurs</h1>
                    <Button
                        onClick={() => this.ToggleModal({})}
                        color="primary">
                        Ajouter
                        <span className="ml-2 oi oi-plus"></span>
                    </Button>
                </div>
                {this.DisplayComponentState()} 
                {this.RenderModal()}
            </section>
        );
    }
}

export default DeliveryMenSection;