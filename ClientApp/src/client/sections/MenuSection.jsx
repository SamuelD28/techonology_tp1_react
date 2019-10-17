import React from 'react';
import MenuItem from '../components/MenuItem';
import Converter from '../../shared/converter';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import Ajax from '../../shared/ajax';

class MenuSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            items: [],
            categories: [],
            displayedCategory: '*',
        };
        fetch(props.requestUrl)
            .then(response => response.json())
            .then(
                result => {
                    if (result['statusCode'] === 200) {

                        let state = this.state;
                        state.items = result['value'];
                        state.categories = state.items.map((menuItem, index) => menuItem.category).filter(this.OnlyUnique);
                        this.setState(state);
                    };
                });
    }

    /**
     * Fileter onliy unique item
     * @param {any} value value to filter
     * @param {any} index current index
     * @param {any} self list
     */
    OnlyUnique(value, index, self) {
        return self.indexOf(value) === index;
    }

    DisplayMenuItems = (category) => {
        return this.state.items.map((menuItem, index) => {
            if (category === '*' || category === menuItem.category) {
                return (<MenuItem
                    key={index}
                    layout="stackedinverted"
                    size={3}
                    name={menuItem.name}
                    img={menuItem.image.file}
                    isBase64={true}
                    description={menuItem.description}
                    price={menuItem.price}
                />
                );
            }
            else {
                return null;
            }
        });
    };


    DisplayCategoryButtons = () => {
        let buttons = this.state.categories.map((category, index) => (
            <button onClick={() => this.SetDisplayedCategory(category)} key={index} className="btn btn-outline-warning mr-1 ml-1">{Converter.IntToCategory(category)}</button>
        ));
        return (
            <div>
                <button onClick={() => this.SetDisplayedCategory('*')} className="btn btn-outline-warning mr-1 ml-1">All</button>
                {buttons}
            </div>
        );
    }

    SetDisplayedCategory = (category) => {
        let state = this.state;
        state.displayedCategory = category;
        this.setState(state);
    }

    render() {
        return (
            <section className="m-4">
                <div className="d-flex justify-content-center">
                    <div className="row no-gutters d-flex mb-5">
                        {this.DisplayCategoryButtons()}
                    </div>
                </div>
                <div className="container-wrap">
                    <div className="row no-gutters d-flex">
                        {this.DisplayMenuItems(this.state.displayedCategory)}
                    </div>
                </div>
            </section >
        )
    }
}

export default MenuSection;
