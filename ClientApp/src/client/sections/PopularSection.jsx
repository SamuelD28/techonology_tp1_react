import React from 'react';
import MenuItem from '../components/MenuItem';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import Ajax from '../../shared/ajax';

class PopularSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            items: []
        };
        fetch(props.requestUrl)
            .then(response => response.json())
            .then(
                result => {
                    if (result['statusCode'] === 200) {
                        
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
                id={menuItem.id}
            />
        ));
    }

    render() {
        return (
            <section className="m-4">
                <div className="container">
                    <div className="row justify-content-center mb-5 pb-3">
                        <div className="col-md-7 heading-section text-center">
                            <h2 className="mb-4">Nos populaires</h2>
                            <p>Voici une selection de nos pizza les plus populaires. Préparer avec amour et soins, ses pizzas seront combler les plus gourmands.</p>
                            <Link to="/menu">
                                <Button color="primary">Voir le menu</Button>
                            </Link>
                        </div>
                    </div>
                </div>
                <div className="container-wrap">
                    <div className="row no-gutters d-flex">
                        {this.DisplayMenuItems()}
                    </div>
                </div>
            </section >
        )
    }
}

export default PopularSection;
