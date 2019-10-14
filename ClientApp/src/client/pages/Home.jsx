import React from 'react';
import { connect } from 'react-redux';
import About from '../sections/About';
import MenuSection from '../sections/MenuSection';

const Home = props => (
    <div>
        <About />
        <MenuSection />
    </div>
);

export default connect()(Home);
