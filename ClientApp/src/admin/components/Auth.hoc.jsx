import React, { Component } from "react";
import Ajax from "../../shared/ajax.js";

export default function(ComposedClass, isPrivate, Role) {
  class AuthenticationCheck extends Component {
    constructor(props) {
      super(props);
      this.state = { loading: true, user: null };
    }

    async componentDidMount() {
      await this.setState({ loading: false });

      let response = await Ajax.GetData("/api/user/auth");
      if (response.statusCode === 200) {
        if(response.value.roles.includes(Role)){

          let user = response.value.user;
          user.roles = response.value.roles;
          this.setState({ user: user });
        }
      } else {
        this.setState({ user: null });

        if(isPrivate){
          this.props.history.push("/connexion");
        }
      }
    }

    render() {
      if (this.state.loading) {
        return <div> Loading </div>;
      } 
      else if(!this.state.user && isPrivate){
        return <div> No access </div>;
      }
      else {
        return <ComposedClass {...this.props} user={this.state.user} />;
      }
    }
  }

  return AuthenticationCheck;
}
