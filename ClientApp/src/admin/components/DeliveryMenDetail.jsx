import React from 'react';
import Ajax from '../../shared/ajax';
import { Alert, Row, Col, Form, FormGroup, Input, Label, Button } from 'reactstrap';
import Confirm from '../../shared/components/Confirm';
import DeliveryManOrders from '../components/DeliveryManOrders';

/**
 *  @description Statefull component responsible for displaying
 *  a form for the delivery man fields. Handles the creation and
 *  modification of a form.
 **/
class DeliveryMenDetail extends React.Component {

    /**
     * @description Constructor for the component. Check if the given
     * object contains information and initialise an update or new state.
     *
     * @param {any} props DeliveryMan
     */
    constructor(props) {
        super(props);

        if (Object.entries(props.deliveryMan).length === 0) {
            this.state = this.ParseNewDeliveryManInState();
        } else {
            this.state = this.ParseDeliveryManInState(props.deliveryMan);
        }
    }

    /**
     * @description Initialise the state to handle the creation of a delviery man
     *
     **/
    ParseNewDeliveryManInState = () => {
        return {
            name: "",
            phone: "",
            isEmployed: false,
            isDeactivated: false,
            new: true,
            formTitle: "Créer un livreur",
            negativeTitle: "Fermer",
            negativeAction: this.props.Done,
            positiveTitle: "Ajouter",
            positiveAction: this.HandlePost,
            errors: []
        };
    }

    /**
     * @description Initialise the state to handle the modification of an
     * existing delivery man.
     *
     **/
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

    /**
     * @description Event handler for changes happening in an input
     *
     * @param {string} key Name of the input
     * @param {any} value Value of the input
     **/
    HandleChange = (key, value) => {
        this.setState({
            [key]: value
        });
    }

    /**
     * @description Method that handle an update request to the api
     *
     **/
    HandleUpdate = async () => {
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

    /**
     *  @description Method that handle a delete request to the api
     *
     **/
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

    /**
     *  @description Method that handle a post request to the api
     *
     **/
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

    /**
     *  @description Display errors to the user if any were encountered during
     *  a request.
     *
     **/
    DisplayErrorMessage = () => {
        if (this.state.errors.length > 0) {
            return (
                <Alert color="danger">Une erreur est survenue.</Alert>
            );
        }
    }

    render() {
        return (
            <Row>
                <Col md="6">
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
                </Col>
                <Col md="6">
                    <DeliveryManOrders
                        deliveryManId={this.state._id}
                    />
                </Col>
            </Row>
        );
    }
}

export default DeliveryMenDetail;