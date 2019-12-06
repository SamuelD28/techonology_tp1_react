import React from 'react';
import Ajax from '../../shared/ajax';
import { Container, Row, Col, Button } from 'reactstrap';
import DeliveyMenSection from '../sections/DeliveryMenSection';
import OrderSection from '../sections/OrderSection';
import MenuItemSection from '../sections/MenuItemSection';
import ImageSection from '../sections/ImageSection';
import Statistic from '../components/Statistic';

class Home extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    logout = async() => {
        let response = await Ajax.GetData("/api/user/logout");

        if(response.statusCode === 200){
            this.props.history.push("/");
        }
    }

    render() {
        return (
            <Container style={{ width: "85%" }} className="p-5" fluid>
                <Button 
                color="primary" 
                className="mb-3"
                onClick={this.logout}>
                    Deconnexion
                </Button>
                <Row noGutters className="h-100 mb-2">
                    <Col md="4">
                        <Statistic
                            title="Ventes"
                            className="mr-2 h-100 bg-dark-transparent"
                            label="par journée"
                            labels={["Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"]}
                            data={[18, 45, 32, 14, 55, 10, 9]} />
                    </Col>
                    <Col md="4">
                        <Statistic
                            title="Livraisons"
                            className="h-100 bg-dark-transparent"
                            labels={["Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"]}
                            label="par journée"
                            data={[32, 5, 23, 61, 11, 13, 99]} />
                    </Col>
                    <Col md="4">
                        <Statistic
                            title="Vente"
                            className="ml-2 h-100 bg-dark-transparent"
                            labels={["Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"]}
                            label="Vente par journée"
                            data={[18, 45, 32, 14, 55, 10, 9]} />
                    </Col>
                </Row>
                <Row noGutters>
                    <Col md="12" className="mb-2">
                        <OrderSection className="bg-dark-transparent" />
                    </Col>
                </Row>
                <Row noGutters>
                    <Col md="6" >
                        <DeliveyMenSection className="bg-dark-transparent" />
                    </Col>
                    <Col md="6">
                        <MenuItemSection className="ml-2 bg-dark-transparent" />
                    </Col>
                    <Col md="12">
                        <ImageSection className="mt-2 bg-dark-transparent" />
                    </Col>
                </Row>
            </Container>
        );
    }

}

export default Home;