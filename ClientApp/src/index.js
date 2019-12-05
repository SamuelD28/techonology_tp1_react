import React from 'react';
import ReactDOM from 'react-dom';
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'react-router-redux';
import { createBrowserHistory } from 'history';
import { StripeProvider } from 'react-stripe-elements';
import Auth from "./admin/components/Auth.hoc.jsx";
import configureStore from './client/store/configureStore';

import Client from './client';
import Admin from './admin';

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;
const store = configureStore(history, initialState);

const rootElement = document.getElementById('root');

ReactDOM.render(
    <StripeProvider apiKey="pk_test_zTJl0RCqc8LVhDilTrQSisJ300Pgg5dQNg">
        <Provider store={store}>
            <ConnectedRouter history={history}>
                <BrowserRouter>
                    <Switch>
                        <Route path='/admin' component={Auth(Admin, true)} />
                        <Route path='/' component={Auth(Client, false)} />
                    </Switch>
                </BrowserRouter>
            </ConnectedRouter>
        </Provider>
    </StripeProvider>,
    rootElement);

