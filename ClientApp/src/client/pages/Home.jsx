import React from 'react';
import { connect } from 'react-redux';
import About from '../sections/About';
import Menu from '../sections/Menu';

const Home = props => (
    <div>
        <About />
        <Menu />
    </div>
);

export default connect()(Home);
