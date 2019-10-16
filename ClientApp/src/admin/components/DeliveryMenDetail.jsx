import React from 'react';
import Ajax from '../../shared/ajax';
import { Form, Row, Col, FormGroup, Input, Label, Button } from 'reactstrap';

class DeliveryMenDetail extends React.Component {

    constructor(props) {
        super(props);

        this.state = {};
        if (props.deliveryMan) {
            this.state = this.ParseDeliveryManInState(props.deliveryMan);
        }
    }

    ConvertResultToYesNo = (result) => {
        return result
            ? <Label className="text-success"> Oui</Label>
            : <Label className="text-danger"> Non</Label>;
    }

    ParseDeliveryManInState = (deliveryMan) => {
        return {
            id: deliveryMan.id,
            name: deliveryMan.name,
            phone: deliveryMan.phone,
            isEmployed: deliveryMan.isEmployed,
            isDeactivated: deliveryMan.isDeactivated
        };
    }

    HandleChange = (event) => {

        this.setState({
            [event.target.name]: event.target.value
        });
    }

    HandleUpdate = async(url) => {
        let request = await Ajax.PutData(`/api/deliverymen/${this.state.id}`, this.state);

        if (request.statusCode >= 200 || request.statusCode <= 300) {
            let updatedDeliveryMan = request.value;
            this.setState(this.ParseDeliveryManInState(updatedDeliveryMan));
            this.props.ToggleModal(null);
            this.props.Refresh();
        }
    }

    HandleDelete = async () => {
        let request = await Ajax.DeleteData(`/api/deliverymen/${this.state.id}`);

        if (request.statusCode >= 200 || request.statusCode <= 300) {
            this.props.ToggleModal(null);
            this.props.Refresh();
        }
    }

    render() {
        return (
            <Form>
                <h1 className="text-primary">{this.props.deliveryMan && this.props.deliveryMan.name}</h1>
                <FormGroup>
                    <Label for="exampleEmail">Nom</Label>
                    <Input
                        type="text"
                        name="name"
                        id="inputName"
                        placeholder="Nom..."
                        value={this.state.name}
                        onChange={this.HandleChange}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="exampleAddress">Téléphone</Label>
                    <Input
                        type="phone"
                        name="phone"
                        id="inputPhone"
                        placeholder="Téléphone..."
                        value={this.state.phone}
                        onChange={this.HandleChange}
                    />
                </FormGroup>
                <Row>
                    <Col md="6">
                        <Label className="mr-2">Est employé : </Label>
                        {this.ConvertResultToYesNo(this.state.isEmployed)}
                    </Col>
                    <Col md="6">
                        <Label className="mr-2">Est désactivé : </Label>
                        {this.ConvertResultToYesNo(this.state.isDeactivated)}
                    </Col>
                </Row>
                <div className="d-flex justify-content-between mt-4">
                    <Button onClick={this.HandleDelete} color="danger">Supprimer</Button>
                    <Button onClick={this.HandleUpdate} color="secondary">Sauvgarder</Button>
                </div>
            </Form>
        );
    }
}

export default DeliveryMenDetail;