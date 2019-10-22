import React from 'react';
import { Modal, ModalBody } from 'reactstrap';

import ImageDetail from '../components/ImageDetail';
import ImageCard from '../components/ImageCard';

import Ajax from '../../shared/ajax';
import Pagination from '../../shared/components/Pagination';
import Loading from '../../shared/components/Loading';
import List from '../../shared/components/List';
import SectionHeader from '../../shared/components/SectionHeader';

class ImageSection extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            modal: false,
            selectedMenuItem: null,
            previousQuery: null,
            currentQuery: "https://servefile.herokuapp.com/images/info",
            nextQuery: null,
        };
    }

    componentDidMount() {
        this.GetImages();
    }

    GetImages = async () => {
        let results = await Ajax.GetData(this.state.currentQuery);

        if (results) {

            let data = results;
            this.setState({
                images: data,
            });
        }

        this.setState({ loading: false });
    }

    RefreshCurrentImages = async (query) => {
        await this.setState({ currentQuery: query });
        this.GetImages();
    }

    ToggleModal = (image) => {
        this.setState({
            modal: !this.state.modal,
            selectedImage: image
        });
    }

    render() {
        return (
            <section className={this.props.className}>
                <SectionHeader
                    title="Les Médias"
                    buttonTitle="Ajouter"
                    buttonIcon="oi-plus"
                    action={() => this.ToggleModal({})}
                    />
                <Loading secondsToWait={1}>
                    <List
                        colSize={3}
                        className="no-gutters"
                        records={this.state.images}>
                        {image => (
                            <ImageCard
                                image={image}
                                showDetails={() => this.ToggleModal(image)}
                                />
                        )}
                    </List>
                </Loading>
                <Modal
                    centered
                    isOpen={this.state.modal}
                    toggle={this.ToggleModal}>
                    <ModalBody className="bg-dark">
                        <ImageDetail
                            Done={this.ToggleModal}
                            Refresh={this.GetImages}
                            menuItem={this.state.selectedImage} />
                    </ModalBody>
                </Modal>
            </section>
        );
    }
}

export default ImageSection;