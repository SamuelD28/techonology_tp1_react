﻿import React from 'react';
import Ajax from '../../shared/ajax';
import { Alert, Form, FormGroup, Input, Label, Button } from 'reactstrap';
import Confirm from '../../shared/components/Confirm';
import ImagePicker from '../../shared/components/ImagePicker';

/**
 *  @description Statefull component responsible for displaying
 *  a form for the menu item fields. Handles the creation and
 *  modification of a form.
 **/
class MenuItemDetail extends React.Component {

    /**
     * @description Constructor for the component. Check if the given
     * object contains information and initialise an update or new state.
     * 
     * @param {any} props DeliveryMan
     */
    constructor(props) {
        super(props);

        if (Object.entries(props.menuItem).length === 0) {
            this.state = this.ParseNewMenuItem();
        } else {
            this.state = this.ParseExistingMenuItem(props.menuItem);
        }
    }

    /**
     * @description Initialise the state to handle the creation of a delviery man
     * 
     **/
    ParseNewMenuItem = () => {
        return {
            name: "",
            price: 0,
            imageUrl: "",
            category: -1,
            description : "",
            new : true,
            formTitle: "Ajouter dans le menu",
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
    ParseExistingMenuItem = (menuItem) => {
        return {
            id: menuItem.id,
            name: menuItem.name,
            price: menuItem.price,
            imageUrl: menuItem.imageUrl,
            category: menuItem.category,
            description: menuItem.description,
            new: false,
            formTitle: "Modifier un item",
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
        let request = await Ajax.PutData(`/api/menuitems/${this.state.id}`, this.state);

        if (request.statusCode >= 200 && request.statusCode <= 300) {
            let updatedMenuItem = request.value;
            this.setState(this.ParseExistingMenuItem(updatedMenuItem));
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
        let request = await Ajax.DeleteData(`/api/menuitems/${this.state.id}`);

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

    render() {
        return (
            <div>
                <Form>
                    <h1 className="text-primary">{this.state.formTitle}</h1>
                    {this.DisplayErrorMessage()}
                    <FormGroup>
                        <Label htmlFor="inputName">Nom</Label>
                        <Input
                            type="text"
                            id="inputName"
                            placeholder="Nom..."
                            value={this.state.name}
                            onChange={(e) => this.HandleChange("name", e.target.value)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label htmlFor="inputCategory">Catégorie</Label>
                        <Input 
                            type="select"
                            id="inputCategory"
                            placeholder="Categorie..."
                            defaultValue={this.state.category}
                            name="category" 
                            onChange={(e) =>  this.HandleChange("category", e.target.value)}>
                            <option className="text-white" value={0}>Pizza</option>
                            <option className="text-white" value={1}>Boisson</option>
                            <option className="text-white" value={2}>Dessert</option>
                            <option className="text-white" value={3}>Autre</option>
                        </Input>
                    </FormGroup>
                    <FormGroup>
                        <Label htmlFor="inputPrice">Prix</Label>
                        <Input
                            type="number"
                            id="inputPrice"
                            placeholder="Prix..."
                            value={this.state.price}
                            onChange={(e) => this.HandleChange("price", e.target.value)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label htmlFor="inputDescription">Description</Label>
                        <Input
                            type="textarea"
                            id="inputDescription"
                            placeholder="Description..."
                            value={this.state.description}
                            onChange={(e) => this.HandleChange("description", e.target.value)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <img 
                            className="mb-2"
                            width="30%"
                            hidden={this.state.imageUrl === ""} 
                            src={this.state.imageUrl}
                            />
                        <ImagePicker
                            setImageUrl={(imageUrl) => this.HandleChange("imageUrl", imageUrl)}>
                            <Button onClick={() => {}}>
                                Choisir une image
                            </Button>
                        </ImagePicker>
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

export default MenuItemDetail;