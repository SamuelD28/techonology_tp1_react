import React from 'react';
import Ajax from '../../shared/ajax';
import { Alert, Form, FormGroup, Input, Label, Button } from 'reactstrap';

/**
 *  @description Statefull component responsible for displaying
 *  a form for the menu item fields. Handles the creation and
 *  modification of a form.
 **/
class Register extends React.Component {

    /**
     * @description Constructor for the component. Check if the given
     * object contains information and initialise an update or new state.
     * 
     * @param {any} props DeliveryMan
     */
    constructor(props) {
        super(props);
        this.state = {
            Username: "",
            Email: "",
            PasswordHash: "",
            PhoneNumber: "",
            Role: "delivery"
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
     *  @description Method that handle a post request to the api
     *  
     **/
    HandlePost = async () => {

        let url = this.state.Role === "delivery" ? "/api/user/register/delivery" : "/api/user/register";
        let request = await Ajax.PostData(url, this.state);

        if (request.statusCode >= 200 && request.statusCode <= 300) {
            alert(`${this.state.Role} créer`);
            this.setState({
                Username: "",
                Email: "",
                PasswordHash: "",
                PhoneNumber: "",
                Role: ""
            });
        } else {
            alert("Erreur de création");
        }
    }

    render() {
        return (
            <div>
                <Form>
                    <h1 className="text-primary">Nouveau Utilisateur</h1>
                    <FormGroup>
                        <Label htmlFor="Username">Nom</Label>
                        <Input
                            type="text"
                            id="Username"
                            placeholder="Username..."
                            value={this.state.name}
                            onChange={(e) => this.HandleChange("Username", e.target.value)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label htmlFor="Email">Email</Label>
                        <Input
                            type="email"
                            id="Email"
                            placeholder="Email..."
                            value={this.state.name}
                            onChange={(e) => this.HandleChange("Email", e.target.value)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label htmlFor="PasswordHash">Password</Label>
                        <Input
                            type="password"
                            id="PasswordHash"
                            placeholder="Password..."
                            value={this.state.PasswordHash}
                            onChange={(e) => this.HandleChange("PasswordHash", e.target.value)}
                        />
                    </FormGroup>
                    <FormGroup>
                        <Label htmlFor="PhoneNumber">Téléphone</Label>
                        <Input
                            type="tel"
                            id="PhoneNumber"
                            placeholder="Téléphone..."
                            value={this.state.PhoneNumber}
                            onChange={(e) => this.HandleChange("PhoneNumber", e.target.value)}
                        />
                    </FormGroup>
                    <Label htmlFor="Role">Catégorie</Label>
                    <Input
                        type="select"
                        id="Role"
                        placeholder="Role..."
                        defaultValue={this.state.Role}
                        name="Role"
                        onChange={(e) => this.HandleChange("Role", e.target.value)}>
                        <option className="text-white" value={"delivery"}>Livreur</option>
                        <option className="text-white" value={"admin"}>Administrateur</option>
                    </Input>
                </Form>
                <div className="d-flex justify-content-between">
                    <Button onClick={this.HandlePost} color="primary">
                        Créer
                    </Button>
                </div>
            </div>
        );
    }
}

export default Register;