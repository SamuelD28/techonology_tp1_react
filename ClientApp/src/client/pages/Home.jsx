import React from 'react';
import { connect } from 'react-redux';
import About from '../sections/About';
import PopularSection from '../sections/PopularSection';
import Routes from '../../shared/routes';

const Home = props => (
    <div>
        <About />
        <PopularSection requestUrl={Routes.api.menuItems.all} />
    </div>
);

export default connect()(Home);
