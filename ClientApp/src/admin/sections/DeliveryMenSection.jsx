﻿import React from 'react';
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
        };
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
            console.log(this.state);
        }
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

    DisplayPagination = () => {
        return (
            <div>
                {this.DisplayCurrentSelection()}
                <div className="d-flex justify-content-between">
                    {this.DisplayPaginationButton(
                        this.state.previousQuery,
                        <span style={{color : "inherit"}}>
                            <i className='oi oi-arrow-left mr-2'></i>
                            Précédent
                        </span>
                    )}
                    {this.DisplayPaginationButton(
                        this.state.nextQuery,
                        <span style={{ color: "inherit" }}>
                            Suivant
                            <i className='oi oi-arrow-right ml-2'></i>
                        </span>
                    )}
                </div>
            </div>
        );
    }

    DisplayPaginationButton = (query, content) => {
        if (query) {
            return (
                <Button
                    onClick={() => this.RefreshCurrentDeliveryMen(query)}
                    color="primary">
                    {content}
                </Button>
            )
        } else {
            return <span></span>
        }
    }

    DisplayCurrentSelection = () => {
        let regex = /[0-9]+/gm;
        let res = this.state.currentQuery.match(regex);
        return <div className="text-center text-white">{res[0]}-{res[1]}</div>
    }

    render() {
        return (
            <section className="bg-secondary p-4 rounded">
                <h1 className="d-flex justify-content-between align-items-center">Les livreurs
                    <Button onClick={() => this.ToggleModal({})} color="primary">Ajouter</Button>
                </h1>
                <Row noGutters>
                    {this.DisplayDeliveryMen()}
                </Row>
                {this.DisplayPagination()}
                {this.RenderModal()}
            </section>
        );
    }
}

export default DeliveryMenSection;