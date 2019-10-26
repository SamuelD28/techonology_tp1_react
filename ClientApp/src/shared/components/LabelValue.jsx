import React from 'react';
import { Col, Row } from 'reactstrap';

/**
 * @description Stateless component that display label and 
 * a value
 * 
 * @param {any} props Label, Value
 */
const LabelValue = props => {

    return (
        <div>
            <label className="mb-0 mr-2">{props.label} : </label>
            <span>{props.value}</span>
        </div>
    );
};

export default LabelValue;