import React from 'react';
import { Card, CardTitle, CardBody, Button, CardSubtitle } from 'reactstrap';

/**
 * @description Component that display information
 * about a menu item in a card format
 * 
 * @param {any} props ClassName, MenuItem
 */
const ImageCard = props => {
    return (
        <div className={`bg-dark d-flex border-bottom border-dark flex-row${props.className}`}>
            <img
                className="img-fit"
                width="20%"
                //src={`data:image/png;base64 , ${props.menuItem.image.file}`}
                src="images/pizza-1.jpg"
                alt="Menu Item image" />
            <div className="p-4 flex-fill d-flex flex-row justify-content-between align-items-center">
                <h3 className="flex-100 m-0">{props.menuItem.name}</h3>
                <h5 className="flex-100 m-0">{props.menuItem.price}$</h5>
                <Button
                    className="flex-80"
                    color="primary"
                    onClick={props.showDetails}>
                    Détails
            </Button>
            </div>
        </div>
    )
}

export default ImageCard;