import React from 'react';
import { Row, Col, Button } from 'reactstrap';

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
            <Row>
                <Col md="5">
                <img
                    className="img-fit img-fluid"
                    src={`https://servefile.herokuapp.com/images/${props.image._id}`}
                        alt="Image" />
                </Col>
                <Col md="7">
                    <LabelValue label="Nom" value={`${props.image.originalname.substring(0, 15)}`} />
                    <LabelValue label="Largeur" value={`${props.image.width} px`} />
                    <LabelValue label="Hauteur" value={`${props.image.height} px`} />
                    <LabelValue label="Taille" value={`${props.image.size / Math.pow(10, 6)} mb`} />
                    <LabelValue label="Type" value={props.image.mimetype} />
                    <Button className="mt-2" color="danger">
                        <span className="oi oi-trash mr-2"></span>
                        Supprimer
                    </Button>
                </Col>
            </Row>
        </div>
    )
}

export default ImageCard;
