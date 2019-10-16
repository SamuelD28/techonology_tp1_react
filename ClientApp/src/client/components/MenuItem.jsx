import React from 'react';
import { Col, Button } from 'reactstrap';

function ChooseLayout(props) {
    if (props.layout === "stackedinverted") {
        return <MenuItemStacked
            name={props.name}
            description={props.description}
            price={props.price}
            img={props.img}
            isBase64={props.isBase64}
        />;
    } else if (props.layout === "stacked") {
        return <MenuItemStacked
            name={props.name}
            description={props.description}
            price={props.price}
            img={props.img}
            isBase64={props.isBase64}
        />;
    } else {
        return <MenuItemPortrait
            name={props.name}
            description={props.description}
            price={props.price}
            img={props.img}
            isBase64={props.isBase64}
        />;
    }
};

const MenuItemStacked = props => (
    <div className="services-wrap d-flex">
        <div className="img" style={StyleImage(props.isBase64, props.img)}></div>
        <div className="text p-4">
            <h3>{props.name}</h3>
            <p>{props.description}</p>
            <p className="price">
                <span>${props.price}</span>
                <button className="ml-2 btn btn-white btn-outline-white">Ajouter</button>
            </p>
        </div>
    </div>
);

const MenuItemStackedInverted = props => (
    <div className="services-wrap d-flex">
        <div className="text p-4">
            <h3>{props.name}</h3>
            <p>{props.description}</p>
            <p className="price">
                <span>${props.price}</span>
                <button className="ml-2 btn btn-white btn-outline-white">Ajouter</button>
            </p>
        </div>
        <div className="img" style={StyleImage(props.isBase64, props.img)}></div>
    </div>
);

const MenuItemPortrait = props => (
    
    <div className="menu-wrap text-center">
        <div className="menu-img img mb-4" style={StyleImage(props.isBase64, props.img)}></div>
        <div className="text">
            <h3><a href="#">{props.name}</a></h3>
            <p>{props.description}</p>
            <p className="price">
                <span>{props.price}</span>
            </p>
            <p>
                <button className="btn btn-white btn-outline-white">Ajouter</button>
            </p>
        </div>
    </div>
);

const StyleImage = (isBase64, img) => {
    console.log(img);
    if (!isBase64)
        return { backgroundImage: `url(${img})` };
    else {
        return { backgroundImage: `url(data:image/png;base64,${img})` };
    }
};

const MenuItem = props => (
    <Col md={props.size}>
        {ChooseLayout(props)}
    </Col>
);

export default MenuItem;