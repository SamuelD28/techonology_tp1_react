import React from 'react';
import MenuSection from '../sections/MenuSection';
import Routes from '../../shared/routes';

const Menu = props => (
    <div>
        <div>
            <h1>Menu Page</h1>
        </div>
        <MenuSection requestUrl={Routes.api.menuItems.all} />
    </div>
);

export default Menu;
