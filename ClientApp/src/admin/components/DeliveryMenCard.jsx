import React from 'react';
import { Card, CardTitle, CardBody, Button, CardSubtitle } from 'reactstrap';

const DeliveryMenCard = props => {
    return (
        <Card className="bg-dark p-4 text-center">
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