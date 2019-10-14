import React from 'react';
import { connect } from 'react-redux';
import Banner from '../sections/Banner';
import About from '../sections/About';
import Menu from '../sections/Menu';
import NavMenu from '../components/NavMenu';

const Home = props => (
    <div>
        <NavMenu />
        <About />
        <Menu />
    </div>
);

export default connect()(Home);
