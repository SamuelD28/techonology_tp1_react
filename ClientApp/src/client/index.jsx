import React from 'react';
import { Route, Switch } from 'react-router';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import NavMenu from './components/NavMenu';
import Home from './pages/Home';
import Menu from './pages/Menu';
import Login from './pages/Login';
import NotFound from './pages/NotFound';
import CartSection from './sections/CartSection';

export default () => (
    <div>
        <NavMenu />
        <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/menu' component={Menu} />
            <Route exact path='/connexion' component={Login} />
            <Route path='/' component={NotFound} />
        </Switch>
        <div className="h-10 d-flex flex-row-reverse fixed-bottom">
            <CartSection/>
        </div>
    </div>
);
