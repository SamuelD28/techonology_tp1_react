import React, { Component } from "react";
import Ajax from "../../shared/ajax.js";

export default function(ComposedClass, isPrivate) {
  class AuthenticationCheck extends Component {
    constructor(props) {
      super(props);
      this.state = { loading: true, errors: [] };
    }

    async componentDidMount() {
      let user = await Ajax.GetData("/api/user/auth");

      if (user.error) {
        this.setState({
          loading: false,
          errors: this.state.errors.push(user.error)
        });
      } else if (!user.isAuth && isPrivate) {
        this.props.history.push("/connexion");
      } else {
        this.setState({ loading: false, user: user });
      }
    }

    render() {
      if (this.state.loading) {
        return <div> Loading </div>;
      } else if (!this.state.loading && this.state.errors.length === 0) {
        return <ComposedClass {...this.props} user={this.state.user} />;
      } else {
        return <h1>Error</h1>;
      }
    }
  }

  return AuthenticationCheck;
}
