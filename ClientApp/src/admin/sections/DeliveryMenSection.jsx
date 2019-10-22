import React from 'react';
import Ajax from '../../shared/ajax';
import { Modal, ModalBody } from 'reactstrap';

import DeliveryMenDetail from '../components/DeliveryMenDetail';
import DeliveryManCard from '../components/DeliveryMenCard';

import Pagination from '../../shared/components/Pagination';
import Loading from '../../shared/components/Loading';
import List from '../../shared/components/List';
import SectionHeader from '../../shared/components/SectionHeader';

/**
 * @description Statefull component responsible for crud operation
 * on the delivery man model.
 * 
 **/
class DeliveryMenSection extends React.Component {

    /**
     * @description Constructor. Initiate the state of the component.
     * 
     * @param {any} props
     */
    constructor(props) {
        super(props);
        this.state = {
            modal: false,
            selectedDeliveryMan: null,
            previousQuery: null,
            currentQuery: "/api/deliverymen?start=0&end=6",
            nextQuery: null,
        };
    }

    componentDidMount() {
        this.GetDeliveryMen();
    }

    /**
     * @description Method that get all the delivery man and put them in the state.
     **/
    GetDeliveryMen = async () => {
        let results = await Ajax.GetData(this.state.currentQuery);

        if (results.statusCode >= 200 || results.statusCode < 300) {
            let data = results.value.data;
            this.setState({
                deliveryMen: data,
                nextQuery: results.value.nextQuery,
                previousQuery: results.value.previousQuery
            });
        }

        this.setState({ loading: false });
    }

    /**
     * @description Method responsible for changing the current delivery men 
     * to the requested query.
     **/
    RefreshCurrentDeliveryMen = async (query) => {
        await this.setState({ currentQuery: query });
        this.GetDeliveryMen();
    }

    /**
     *  @description Method that open and close a modal dialog.
     *  
     **/
    ToggleModal = (deliveryMan) => {
        this.setState({
            modal: !this.state.modal,
            selectedDeliveryMan: deliveryMan
        });
    }

    render() {
        return (
            <section className={this.props.className}>
                <SectionHeader
                    title="Les livreurs"
                    buttonTitle="Ajouter"
                    buttonIcon="oi-plus"
                    action={() => this.ToggleModal({})}
                    />
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
                <Modal
                    centered
                    isOpen={this.state.modal}
                    toggle={this.ToggleModal}>
                    <ModalBody className="bg-dark">
                        <DeliveryMenDetail
                            Done={this.ToggleModal}
                            Refresh={this.GetDeliveryMen}
                            deliveryMan={this.state.selectedDeliveryMan} />
                    </ModalBody>
                </Modal>
            </section>
        );
    }
}

export default DeliveryMenSection;