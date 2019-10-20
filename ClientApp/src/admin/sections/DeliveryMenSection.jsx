import React from 'react';
import Ajax from '../../shared/ajax';
import DeliveryMenDetail from '../components/DeliveryMenDetail';
import { Col, Modal, ModalBody, Row, Button } from 'reactstrap';
import DeliveryManCard from '../components/DeliveryMenCard';

import Pagination from '../../shared/components/Pagination';
import Loading from '../../shared/components/Loading';
import List from '../../shared/components/List';

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
            operationLatency: 1000
        };
    }

    componentDidMount() {
        this.GetDeliveryMen();
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
                <Loading secondsToWait={1}>
                    <List
                        colSize={4}
                        className="no-gutters"
                        records={this.state.deliveryMen}>
                        {deliveryMan => (
                            <DeliveryManCard
                                className="h-100"
                                deliveryMan={deliveryMan}
                                showDetails={() => this.ToggleModal(deliveryMan)}
                                />
                        )}
                    </List>
                    <Pagination
                        GetData={this.RefreshCurrentDeliveryMen}
                        previousQuery={this.state.previousQuery}
                        currentQuery={this.state.currentQuery}
                        nextQuery={this.state.nextQuery}
                        />
                </Loading>
                {this.RenderModal()}
            </section>
        );
    }
}

export default DeliveryMenSection;