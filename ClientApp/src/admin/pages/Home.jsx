import React from 'react';
import Ajax from '../../shared/ajax';
import { Container, Row, Col } from 'reactstrap';
import DeliveyMenSection from '../sections/DeliveryMenSection';
import MenuItemSection from '../sections/MenuItemSection';

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        return (
            <Container style={{width : "85%"}} className="p-5" fluid>
                <Row className="no-gutters justify-content-between"> 
                    <Col md="5">
                        <DeliveyMenSection />
                    </Col>
                    <Col md="6">
                        <MenuItemSection />
                    </Col>
                </Row>
            </Container>
        );
    }

}

export default Home;