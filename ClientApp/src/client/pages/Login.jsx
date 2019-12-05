import React, { Component } from "react";
import {
  Col,
  Card,
  CardHeader,
  CardBody,
  Input,
  Button,
  Alert
} from "reactstrap";
import Ajax from "../../shared/ajax.js";

class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      Username: "",
			PasswordHash: "",
			Error: ""
    };
  }

  handleChange = e => {
    this.setState({ [`${e.target.name}`]: e.target.value });
  };

  login = async () => {
		this.setState({Error: ""});
		
		let response = await Ajax.PostData("/api/user/login", this.state);

    if (response.statusCode === 200) {
      this.props.history.push("/admin");
    } else {
			this.setState({Error: "Mauvais username ou mot de passe"});
    }
  };

  render() {
    return (
      <div className="d-flex mt-5 justify-content-center align-items-center">
        <Col md="4">
          <Card className="bg-dark">
            <CardHeader>
              <h2 className="text-primary">Page de connexion</h2>
            </CardHeader>
            <CardBody>
              <Alert hidden={this.state.Error === ""} color="danger">
                Mauvais username ou mot de passe
              </Alert>
              <Input
                name="Username"
                type="text"
                placeholder="Utilisateur"
                value={this.state.Username}
                onChange={this.handleChange}
                required
              />
              <Input
                name="PasswordHash"
                type="password"
                placeholder="Mot de passe"
                value={this.state.Password}
                onChange={this.handleChange}
                required
              />
              <Button onClick={this.login} className="mt-4" color="primary">
                Se Connecter
              </Button>
            </CardBody>
          </Card>
        </Col>
      </div>
    );
  }
}

export default Login;
