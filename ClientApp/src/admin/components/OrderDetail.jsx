import React from 'react';
import Ajax from '../../shared/ajax';
import { Alert, Form, FormGroup, Input, Label, Button } from 'reactstrap';
import Confirm from '../../shared/components/Confirm';
import ApiRequest from '../../shared/api/apiRequest';

/**
 *  @description Statefull component responsible for displaying
 *  a form for the menu item fields. Handles the creation and
 *  modification of a form.
 **/
class OrderDetail extends React.Component {

    /**
     * @description Constructor for the component. Check if the given
     * object contains information and initialise an update or new state.
     * 
     * @param {any} props DeliveryMan
     */
    constructor(props) {
        super(props);

        if (Object.entries(props.order).length === 0) {
            this.state = this.ParseNewOrder();
        } else {
            this.state = this.ParseExistinOrder(props.order);
        }

        let self = this;
        this.apiRequest = new ApiRequest();
        this.deliveryMen = [];
        this.apiRequest.GetAllDeliveryMen().then(
            (result) => {
                self.deliveryMen = result;
                self.setState(self.state);
            });
    }

    /**
     * @description Initialise the state to handle the creation of a delviery man
     * 
     **/
    ParseNewOrder = () => {
        return {
            id: 0,
            customerName: '',
            customerAdress: '',
            customerPhoneNumber: '',
            ordersItems: [],
            deliveryMan: null,
            new: false,
            formTitle: "Modifier une commande",
            negativeTitle: "Supprimer",
            negativeAction: this.HandleDelete,
            positiveTitle: "Sauvgarder",
            positiveAction: this.HandleUpdate,
            errors: []
        };
    }

    /**
     * @description Initialise the state to handle the modification of an 
     * existing delivery man.
     * 
     **/
    ParseExistinOrder = (order) => {
        if (order.deliveryManId === undefined || order.deliveryManId === null) {
            order.deliveryManId = 0;
        }
        return {
            id: order.id,
            customerName: order.customerName,
            customerAdress: order.customerAdress,
            customerPhoneNumber: order.customerPhoneNumber,
            ordersItems: order.ordersItems,
            deliveryManId: order.deliveryManId,
            new: false,
            formTitle: "Modifier une commande",
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
        let updatedOrder = await this.apiRequest.UpdateOrder(this.state);

        if (updatedOrder !== null) {
            this.setState(this.ParseExistinOrder(updatedOrder));
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
        //let request = await Ajax.PutData(`/api/orders/${this.state.id}`, this.state);

        //if (request.statusCode >= 200 && request.statusCode <= 300) {
        //    let updatedMenuItem = request.value;
        //    this.setState(this.ParseExistingMenuItem(updatedMenuItem));
        //    this.props.Done();
        //    this.props.Refresh();
        //} else {
        //    this.setState({
        //        errors: [
        //            {
        //                path: "name",
        //                message: "Nom est requis"
        //            }
        //        ]
        //    });
        //}
    }

    /**
     *  @description Method that handle a delete request to the api
     *  
     **/
    HandleDelete = async () => {
        let deletedOrder = await this.apiRequest.DeleteOrder(this.state.id);

        if (deletedOrder !== null) {
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
        //let request = await Ajax.DeleteData(`/api/menuitems/${this.state.id}`);

        //if (request.statusCode >= 200 && request.statusCode <= 300) {
        //    this.props.Done();
        //    this.props.Refresh();
        //} else {
        //    this.setState({
        //        errors: [
        //            {
        //                path: "name",
        //                message: "Nom est requis"
        //            }
        //        ]
        //    });
        //}
    }

    /**
     *  @description Method that handle a post request to the api
     *  
     **/
    HandlePost = async () => {
        let request = await Ajax.PostData(`/api/menuitems`, this.state);

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

    /**
     * @description Display all deliveryMan in option. The admin will be able to select one of them
     **/
    DisplayDeliveryManOption = () => {
        if(this.deliveryMen){
            let self = this;
            let options = this.deliveryMen.map((deliveryMan, index) => {
                return self.CreateOption(deliveryMan.id, deliveryMan.name);
            });
            options.push(this.CreateOption(0, 'Aucun'));
            return options;
        }
    }

    /**
     * @description Display all deliveryMan in option. The admin will be able to select one of them
     * 
     * @param {int} id deliveryMan's id
     * @param {string} name deliveryMan's name
     * */
    CreateOption = (id, name) => {
        return <option value={id}>{name}</option>
    }

    render() {
        return (
            <div>
                <Form>
                    <h1 className="text-primary">{this.state.formTitle}</h1>
                    <FormGroup>
                        <label htmlFor="customerName">Nom:</label>
                        <input type="text" className="form-control" id="customerName" value={this.state.customerName} disabled />
                    </FormGroup>
                    <FormGroup>
                        <label htmlFor="customerAdress">Adresse:</label>
                        <input type="text" className="form-control" id="customerAdress" value={this.state.customerAdress} disabled />
                    </FormGroup>
                    <FormGroup>
                        <label htmlFor="customerPhoneNumber">Téléphone:</label>
                        <input type="text" className="form-control" id="customerPhoneNumber" value={this.state.customerPhoneNumber} disabled />
                    </FormGroup>
                    <FormGroup>
                        <label htmlFor="deliveryMan">Livreur:</label>
                        <select className="form-control" value={this.state.deliveryManId} onChange={(e) => this.HandleChange("deliveryManId", e.target.value)} id="deliveryMan">
                            {this.DisplayDeliveryManOption()}
                        </select>
                    </FormGroup>
                </Form>
                <div className="d-flex justify-content-between">
                    <Confirm
                        message={`Voulez-vous vraiment ${this.state.negativeTitle} ce menu?`}
                        trigger={<Button color="danger">{this.state.negativeTitle}</Button>}
                        successAction={this.state.negativeAction} />
                    <Confirm
                        message={`Voulez-vous vraiment ${this.state.positiveTitle} ce menu?`}
                        trigger={<Button color="success">{this.state.positiveTitle}</Button>}
                        successAction={this.state.positiveAction} />
                </div>
            </div>
        );
    }
}

export default OrderDetail;