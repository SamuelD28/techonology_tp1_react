import React from 'react';
import { Button } from 'reactstrap';

/**
 * @description Method that display a section header with an
 * action button.
 * 
 * @param {any} props
 */
const SectionHeader = props => {

    return (
        <div className="d-flex section-bg justify-content-between align-items-center p-4">
            <h1 className="section-title">{props.title}</h1>
            <Button
                onClick={() => props.action()}
                color="primary">
                {props.buttonTitle}
                <span className={`ml-2 oi ${props.buttonIcon}`}></span>
            </Button>
        </div>
    );
};

export default SectionHeader;