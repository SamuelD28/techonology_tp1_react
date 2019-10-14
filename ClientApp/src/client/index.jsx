import React from 'react';
import { Route, Switch } from 'react-router';

import NavMenu from './components/NavMenu';
import Home from './pages/Home';
import Menu from './pages/Menu';
import Login from './pages/Login';
import NotFound from './pages/NotFound';

export default () => (
    <div>
        <NavMenu />
        <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/menu' component={Menu} />
            <Route exact path='/connexion' component={Login} />
            <Route path='/' component={NotFound} />
        </Switch>
    </div>
);
