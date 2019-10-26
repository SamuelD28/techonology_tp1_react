import React from 'react';
import Ajax from '../../shared/ajax';
import { Container, Row, Col } from 'reactstrap';
import DeliveyMenSection from '../sections/DeliveryMenSection';

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        return (
            <Container className="mx-5 mt-5" fluid>
                <Row noGutters>
                    <Col md="6">
                        <DeliveyMenSection />
                    </Col>
                </Row>
            </Container>
        );
    }

}

export default Home;