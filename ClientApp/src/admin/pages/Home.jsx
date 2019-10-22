import React from 'react';
import Ajax from '../../shared/ajax';
import { Container, Row, Col } from 'reactstrap';
import DeliveyMenSection from '../sections/DeliveryMenSection';
import MenuItemSection from '../sections/MenuItemSection';
import ImageSection from '../sections/ImageSection';

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        return (
            <Container style={{ width: "85%" }} className="p-5" fluid>
                <Row noGutters className="justify-content-between align-items-start">
                    <Col md="6" >
                        <DeliveyMenSection className="mr-2 bg-dark-transparent" />
                    </Col>
                    <Col md="6">
                        <MenuItemSection className="ml-2 bg-dark-transparent"/>
                    </Col>
                    <Col md="12">
                        <ImageSection className="mt-4 bg-dark-transparent"/>
                    </Col>
                </Row>
            </Container>
        );
    }

}

export default Home;