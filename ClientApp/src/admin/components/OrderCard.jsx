import React from 'react';
import Ajax from '../../shared/ajax';
import { Card, CardTitle, CardBody, Button, CardSubtitle } from 'reactstrap';


/**
 * @description Component that display information
 * about a menu item in a card format
 *
 * @param {any} props ClassName, MenuItem
 */
const OrderCard = props => {
    return (
        <div className={`bg-dark d-flex border-bottom border-dark flex-row${props.className}`}>
            <div className="p-4 flex-fill d-flex flex-row justify-content-between align-items-center">
                <h3 className="flex-100 m-0">{props.order.customerName}</h3>
                <h3 className="flex-100 m-0">{props.order.customerAdress}</h3>
                <h3 className="flex-100 m-0">{props.order.customerPhoneNumber}</h3>
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

export default OrderCard;