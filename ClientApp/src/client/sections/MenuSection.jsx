import React from 'react';
import MenuItem from '../components/MenuItem';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import Ajax from '../../shared/ajax';

class MenuSection extends React.Component {

    constructor(props) {
        super(props);
        
        this.state = {
            items: []
        };
        fetch(props.requestUrl)
            .then(response => response.json())
            .then(
                result => {
                    if (result['statusCode'] == 200) {
                        
                        let state = this.state;
                        state.items = result['value'];
                        this.setState(state);
                    };
                });
    }

    DisplayMenuItems = () => {
        return this.state.items.map((menuItem, index) => (
            <MenuItem
                key={index}
                layout="stackedinverted"
                size={3}
                name={menuItem.name}
                img={menuItem.image.file}
                isBase64={true}
                description={menuItem.description}
                price={menuItem.price}
            />
        ));
    }

    render() {
        return (
            <section className="m-4">
                <div className="container-wrap">
                    <div className="row no-gutters d-flex">
                        {this.DisplayMenuItems()}
                    </div>
                </div>
            </section >
        )
    }
}

export default MenuSection;
