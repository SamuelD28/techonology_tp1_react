import React from 'react';
import { Col } from 'reactstrap';

function ChooseLayout(props) {
    if (props.inverted) {
        return (
            <div className="services-wrap d-flex">
                <div className="img" style={{ backgroundImage: `url(${props.img})` }}></div>
                <div className="text p-4">
                    <h3>{props.name}</h3>
                    <p>{props.description}</p>
                    <p className="price">
                        <span>${props.price}</span>
                        <button className="ml-2 btn btn-white btn-outline-white">Ajouter</button>
                    </p>
                </div>
            </div>
        )
    } else {
        return (
            <div className="services-wrap d-flex">
                <div className="text p-4">
                    <h3>{props.name}</h3>
                    <p>{props.description}</p>
                    <p className="price">
                        <span>${props.price}</span>
                        <button className="ml-2 btn btn-white btn-outline-white">Ajouter</button>
                    </p>
                </div>
                <div className="img" style={{ backgroundImage: `url(${props.img})` }}></div>
            </div>
        )
    }
}

const MenuItem = props => (
    <Col lg="4">
        {ChooseLayout(props)}
    </Col>
);

export default MenuItem;