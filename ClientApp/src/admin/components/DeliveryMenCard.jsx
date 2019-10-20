import React from 'react';
import { Card, CardTitle, CardBody, Button, CardSubtitle } from 'reactstrap';

/**
 * @description Component that display information
 * about a delivry man in a card format
 * 
 * @param {any} props ClassName, DeliveryMan
 */
const DeliveryMenCard = props => {
    return (
        <Card className={`bg-dark p-4 text-center ${props.className}`}>
            <img
                className="mx-auto"
                width="50%"
                src="/images/female_avatar.svg"
                alt="User Profile picture" />
            <CardBody>
                <CardTitle>{props.deliveryMan.name}</CardTitle>
                <CardSubtitle>{props.deliveryMan.phone}</CardSubtitle>
                <Button
                    className="mt-4"
                    color="primary"
                    onClick={props.showDetails}>
                    Détails
                    </Button>
            </CardBody>
        </Card>
    )
}

export default DeliveryMenCard;