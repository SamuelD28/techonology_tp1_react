import React from 'react';
import { Modal, ModalBody } from 'reactstrap';

import MenuItemDetail from '../components/MenuItemDetail';
import MenuItemCard from '../components/MenuItemCard';

import Ajax from '../../shared/ajax';
import Pagination from '../../shared/components/Pagination';
import Loading from '../../shared/components/Loading';
import List from '../../shared/components/List';
import SectionHeader from '../../shared/components/SectionHeader';

class MenuItemSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            modal: false,
            selectedMenuItem: null,
            previousQuery: null,
            currentQuery: "/api/menuitems?start=0&end=3",
            nextQuery: null,
        };
    }

    componentDidMount() {
        this.GetMenuItems();
    }

    GetMenuItems = async () => {
        let results = await Ajax.GetData(this.state.currentQuery);

        if (results.statusCode >= 200 || results.statusCode < 300) {

            let data = results.value.data;
            this.setState({
                menuItems: data,
                nextQuery: results.value.nextQuery,
                previousQuery: results.value.previousQuery
            });
        }

        this.setState({ loading: false });
    }

    RefreshCurrentMenuItems = async (query) => {
        await this.setState({ currentQuery: query });
        this.GetMenuItems();
    }

    ToggleModal = (menuItem) => {
        this.setState({
            modal: !this.state.modal,
            selectedMenuItem: menuItem
        });
    }

    render() {
        return (
            <section className="section-bg rounded-lg">
                <SectionHeader
                    title="Le Menu"
                    buttonTitle="Ajouter"
                    buttonIcon="oi-plus"
                    action={() => this.ToggleModal({})}
                    />
                <Loading secondsToWait={1}>
                    <List
                        colSize={12}
                        className="no-gutters"
                        records={this.state.menuItems}>
                        {menuItem => (
                            <MenuItemCard
                                menuItem={menuItem}
                                showDetails={() => this.ToggleModal(menuItem)}
                                />
                        )}
                    </List>
                    <Pagination
                        GetData={this.RefreshCurrentMenuItems}
                        previousQuery={this.state.previousQuery}
                        currentQuery={this.state.currentQuery}
                        nextQuery={this.state.nextQuery}
                        />
                </Loading>
                <Pagination
                    GetData={this.RefreshCurrentMenuItems}
                    previousQuery={this.state.previousQuery}
                    currentQuery={this.state.currentQuery}
                    nextQuery={this.state.nextQuery}
                    />
                <Modal
                    centered
                    isOpen={this.state.modal}
                    toggle={this.ToggleModal}>
                    <ModalBody className="bg-dark">
                        <MenuItemDetail
                            Done={this.ToggleModal}
                            Refresh={this.GetMenuItems}
                            menuItem={this.state.selectedMenuItem} />
                    </ModalBody>
                </Modal>
            </section>
        );
    }
}

export default MenuItemSection;