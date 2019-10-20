import React from 'react';
import { Col, Row } from 'reactstrap';

const List = props => {

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