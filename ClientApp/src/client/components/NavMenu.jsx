import React from 'react';
import {
    Nav,
    Navbar,
    NavbarBrand,
    NavItem
} from 'reactstrap';
import { NavLink } from 'react-router-dom';

export default class NavMenu extends React.Component {
    render() {
        return (
            <Navbar className="ftco-navbar-light"
                color="dark"
                sticky="top"
                expand="md">
                <div className="container">
                    <NavLink to='/'>
                        <NavbarBrand href="/">Pizza<br /><small>Délicieuse</small></NavbarBrand>
                    </NavLink >
                    <Nav className="ml-auto" navbar>
                        <NavItem>
                            <NavLink className="nav-link" activeClassName="active-navbar-item" exact to='/menu'>Menu</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink className="nav-link" activeClassName="active-navbar-item" exact to="/connexion">Connexion</NavLink>
                        </NavItem>
                    </Nav>
                </div>
            </Navbar>
        );
    }
}
