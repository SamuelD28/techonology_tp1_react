import React from 'react';
import { connect } from 'react-redux';
import About from '../sections/About';
import MenuSection from '../sections/MenuSection';
import Routes from '../../shared/routes';

const Home = props => (
    <div>
        <About />
        <MenuSection requestUrl={Routes.api.menuItems.all} />
    </div>
);

export default connect()(Home);
