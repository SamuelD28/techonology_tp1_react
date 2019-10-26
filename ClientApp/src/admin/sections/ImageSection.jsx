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
        this.imageInput = React.createRef();
        this.state = {
            modal: false,
            selectedMenuItem: null,
            previousQuery: null,
            currentQuery: "https://servefile.herokuapp.com/images/info?start=0&end=4",
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
    }

    RefreshCurrentImages = async (query) => {
        await this.setState({ currentQuery: query });
        this.GetImages();
    }

    OpenFileBrowser = () => {

        this.imageInput.current.click();
    }

    UploadImage = (e) => {
        let file = e.target.files[0];

        console.log(file);

        if (file) {

            let formData = new FormData();
            formData.append("image", file);

            fetch('https://servefile.herokuapp.com/images/upload',
                { 
                    method: 'POST',
                    body: formData 
                })
                .then((res) => {
                    this.GetImages();
                })
                .catch((err) => {
                    console.log(err);
                });
        }
    }

    render() {
        return (
            <section className={this.props.className}>
                <SectionHeader
                    title="Les Médias"
                    buttonTitle="Ajouter"
                    buttonIcon="oi-plus"
                    action={this.OpenFileBrowser}
                />
                <input
                    ref={this.imageInput}
                    type="file"
                    style={{ display: "none" }}
                    name="image"
                    onChange={this.UploadImage}
                />
                <Loading secondsToWait={1.25}>
                    <List
                        colSize={3}
                        className="no-gutters"
                        records={this.state.images}>
                        {image => (
                            <ImageCard
                                image={image}
                                refresh={this.GetImages}
                                showDetails={() => this.ToggleModal(image)}
                                />
                        )}
                    </List>
                    <Pagination
                        GetData={this.RefreshCurrentImages}
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