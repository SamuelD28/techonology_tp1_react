import React from "react";
import { Route, Switch } from "react-router-dom";
import NavMenu from "./components/NavMenu";
import Home from "./pages/Home";
import Menu from "./pages/Menu";
import Login from "./pages/Login";
import NotFound from "./pages/NotFound";
import CartSection from "./sections/CartSection";

export default props => (
  <div>
    <NavMenu />
    <Switch>
      <Route exact path="/" render={() => <Home {...props} />} />
      <Route exact path="/menu" render={() => <Menu {...props} />} />
      <Route exact path="/connexion" render={() => <Login {...props} />} />
      <Route path="/" render={() => <NotFound {...props} />} />
    </Switch>
    <CartSection {...props} />
  </div>
);
