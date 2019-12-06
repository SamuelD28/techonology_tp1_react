import React from 'react';
import { Modal, ModalBody } from 'reactstrap';

import OrderDetail from '../components/OrderDetail';
import OrderCard from '../components/OrderCard';

import Loading from '../../shared/components/Loading';
import List from '../../shared/components/List';
import SectionHeader from '../../shared/components/SectionHeader';
import ApiRequest from '../../shared/api/apiRequest';

class OrderSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            modal: false,
            selectedOrder: null,
        };
        this.apiRequest = new ApiRequest();
    }

    componentDidMount() {
        this.GetOrders();
    }

    GetOrders = async () => {
        let results = await this.apiRequest.GetAllOrders();

        if (results !== null) {

            let data = results;
            this.setState({
                Orders: data
            });
        }

        this.setState({ loading: false });
    }

    ToggleModal = (order) => {
        this.setState({
            modal: !this.state.modal,
            selectedOrder: order
        });
    }

    render() {
        return (
            <section className={this.props.className}>
                <SectionHeader
                    title="Les commandes"
                    hasButton={false}
                />
                <Loading secondsToWait={1.5}>
                    <List
                        colSize={12}
                        className="no-gutters"
                        records={this.state.Orders}>
                        {Orders => (
                            <OrderCard
                                order={Orders}
                                showDetails={() => this.ToggleModal(Orders)}
                            />
                        )}
                    </List>
                </Loading>
                <Modal
                    centered
                    isOpen={this.state.modal}
                    toggle={this.ToggleModal}>
                    <ModalBody className="bg-dark">
                        <OrderDetail
                            Done={this.ToggleModal}
                            Refresh={this.GetOrders}
                            order={this.state.selectedOrder} />
                    </ModalBody>
                </Modal>
            </section>
        );
    }
}

export default OrderSection;