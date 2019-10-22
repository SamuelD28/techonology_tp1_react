import React from 'react';
import { Row, Col } from 'reactstrap';

import LabelValue from '../../shared/components/LabelValue';

/**
 * @description Component that display information
 * about a menu item in a card format
 * 
 * @param {any} props ClassName, MenuItem
 */
const ImageCard = props => {
    return (
        <div className={`bg-dark border border-dark p-2 ${props.className}`}>
            <img
                className="img-fit"
                width="40%"
                src={`https://servefile.herokuapp.com/images/${props.image._id}`}
                alt="Image" />
            <Row>
                <Col md="12">
                    <LabelValue label="Nom" value={props.image.originalname} />
                    <LabelValue label="Largeur" value={props.image.width} />
                    <LabelValue label="Hauteur" value={props.image.height} />
                    <LabelValue label="Taille" value={props.image.size} />
                    <LabelValue label="Type" value={props.image.mimetype} />
                </Col>
            </Row>
        </div>
    )
}

export default ImageCard;
