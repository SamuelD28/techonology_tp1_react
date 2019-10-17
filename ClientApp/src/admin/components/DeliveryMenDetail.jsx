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

    HandleChange = (key, value) => {
        this.setState({
            [key]: value
        });
    }

    HandleUpdate = async (url) => {
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
                    <Label htmlFor="exampleEmail">Nom</Label>
                    <Input
                        type="text"
                        id="inputName"
                        placeholder="Nom..."
                        value={this.state.name}
                        onChange={(e) => this.HandleChange("name", e.target.value)}
                    />
                </FormGroup>
                <FormGroup>
                    <Label htmlFor="exampleAddress">Téléphone</Label>
                    <Input
                        type="phone"
                        id="inputPhone"
                        placeholder="Téléphone..."
                        value={this.state.phone}
                        onChange={(e) => this.HandleChange("phone", e.target.value)}
                    />
                </FormGroup>
                <FormGroup>
                    <Input
                        className="inp-cbx"
                        id="isEmployed"
                        style={{ display: "none" }}
                        type="checkbox"
                        checked={this.state.isEmployed}
                        onChange={(e) => this.HandleChange("isEmployed", !this.state.isEmployed)}
                    />
                    <label className="cbx" htmlFor="isEmployed">
                        <span>
                            <svg width="12px" height="10px" viewBox="0 0 12 10">
                                <polyline points="1.5 6 4.5 9 10.5 1"></polyline>
                            </svg>
                        </span>
                        <span>Employé</span>
                    </label>
                </FormGroup>
                <FormGroup>
                    <Input
                        className="inp-cbx"
                        id="isDeactivated"
                        style={{ display: "none" }}
                        type="checkbox"
                        checked={this.state.isDeactivated}
                        onChange={(e) => this.HandleChange("isDeactivated", !this.state.isDeactivated)}
                    />
                    <label className="cbx" htmlFor="isDeactivated">
                        <span>
                            <svg width="12px" height="10px" viewBox="0 0 12 10">
                                <polyline points="1.5 6 4.5 9 10.5 1"></polyline>
                            </svg>
                        </span>
                        <span>Désactivé</span>
                    </label>
                </FormGroup>
                <div className="d-flex justify-content-between mt-4">
                    <Button onClick={this.HandleDelete} color="danger">Supprimer</Button>
                    <Button onClick={this.HandleUpdate} color="success">Sauvgarder</Button>
                </div>
            </Form>
        );
    }
}

export default DeliveryMenDetail;