import React from 'react';
import { Row, Col } from 'reactstrap';
import OrderSection from '../sections/OrderSection';

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        return (
            <Row noGutters>
                <Col md="12" className="mb-2">
                    <OrderSection className="bg-dark-transparent" />
                </Col>
            </Row>
        );
    }

}

export default Home;