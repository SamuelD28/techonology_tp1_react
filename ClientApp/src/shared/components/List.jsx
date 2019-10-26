import React from 'react';
import { Col, Row } from 'reactstrap';

/**
 * @description Stateless component that display a list 
 * passed as a props.
 * 
 * @param {any} props Children, records
 */
const List = props => {

    /**
     * @description Display the specified list if its not empty. 
     * 
     **/
    const DisplayRecords = () => {
        if (props.records) {
            return props.records.map((records, index) => (
                <Col
                    md={props.colSize}
                    key={index}>
                    {props.children(records)}      
                </Col>
            ));
        }
    }

    return (
        <Row className={props.className}>
            {DisplayRecords()}
        </Row>
    );
};

export default List;