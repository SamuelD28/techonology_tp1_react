import React from 'react';
import Ajax from '../../shared/ajax';
import { Alert, Form, Row, Col, FormGroup, Input, Label, Button } from 'reactstrap';
import Confirm from '../../shared/components/Confirm';

class DeliveryMenDetail extends React.Component {

    constructor(props) {
        super(props);

        if (Object.entries(props.deliveryMan).length === 0) {
            this.state = this.ParseNewDeliveryManInState();
        } else {
            this.state = this.ParseDeliveryManInState(props.deliveryMan);
        }
    }

    ParseNewDeliveryManInState = () => {
        return {
            name: "",
            phone: "",
            isEmployed: false,
            isDeactivated: false,
            new: true,
            formTitle: "Cr�er un livreur",
            negativeTitle: "Fermer",
            negativeAction: this.props.Done,
            positiveTitle: "Ajouter",
            positiveAction: this.HandlePost,
            errors: []
        };
    }

    ParseDeliveryManInState = (deliveryMan) => {
        return {
            id: deliveryMan.id,
            name: deliveryMan.name,
            phone: deliveryMan.phone,
            isEmployed: deliveryMan.isEmployed,
            isDeactivated: deliveryMan.isDeactivated,
            new: false,
            formTitle: "Modifier un livreur",
            negativeTitle: "Supprimer",
            negativeAction: this.HandleDelete,
            positiveTitle: "Sauvgarder",
            positiveAction: this.HandleUpdate,
            errors: []
        };
    }

    HandleChange = (key, value) => {
        this.setState({
            [key]: value
        });
    }

    HandleUpdate = async (url) => {
        let request = await Ajax.PutData(`/api/deliverymen/${this.state.id}`, this.state);

        if (request.statusCode >= 200 && request.statusCode <= 300) {
            let updatedDeliveryMan = request.value;
            this.setState(this.ParseDeliveryManInState(updatedDeliveryMan));
            this.props.Done();
            this.props.Refresh();
        } else {
            this.setState({
                errors: [
                    {
                        path: "name",
                        message: "Nom est requis"
                    }
                ]
            });
        }
    }

    HandleDelete = async () => {
        let request = await Ajax.DeleteData(`/api/deliverymen/${this.state.id}`);

        if (request.statusCode >= 200 && request.statusCode <= 300) {
            this.props.Done();
            this.props.Refresh();
        } else {
            this.setState({
                errors: [
                    {
                        path: "name",
                        message: "Nom est requis"
                    }
                ]
            });
        }
    }

    HandlePost = async () => {
        let request = await Ajax.PostData(`/api/deliverymen`, this.state);

        if (request.statusCode >= 200 && request.statusCode <= 300) {
            this.props.Done();
            this.props.Refresh();
        } else {
            this.setState({
                errors: [
                    {
                        path: "name",
                        message: "Nom est requis"
                    }
                ]
            });
        }
    }

    DisplayErrorMessage = () => {
        if (this.state.errors.length > 0) {
            return (
                <Alert color="danger">Une erreur est survenue.</Alert>
            );
        }
    }

    render() {
        return (
            <div>
                <Form>
                    <h1 className="text-primary">{this.state.formTitle}</h1>
                    {this.DisplayErrorMessage()}
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
                        <Label htmlFor="exampleAddress">T�l�phone</Label>
                        <Input
                            type="phone"
                            id="inputPhone"
                            placeholder="T�l�phone..."
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
                            <span>Employ�</span>
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
                            <span>D�sactiv�</span>
                        </label>
                    </FormGroup>
                </Form>
                <div className="d-flex justify-content-between">
                    <Confirm
                        message={`Voulez-vous vraiment ${this.state.negativeTitle} ce livreur?`}
                        trigger={<Button color="danger">{this.state.negativeTitle}</Button>}
                        successAction={this.state.negativeAction} />
                    <Confirm
                        message={`Voulez-vous vraiment ${this.state.positiveTitle} ce livreur?`}
                        trigger={<Button color="success">{this.state.positiveTitle}</Button>}
                        successAction={this.state.positiveAction} />
                </div>
            </div>
        );
    }
}

export default DeliveryMenDetail;