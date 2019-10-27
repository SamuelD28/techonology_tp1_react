import React from 'react';
import { Button } from 'reactstrap';

const RenderActionButton = (props) => {
    if (props.action) {
        return (
            <Button
                onClick={() => props.action()}
                color="primary">
                {props.buttonTitle}
                <span className={`ml-2 oi ${props.buttonIcon}`}></span>
            </Button>
        );
    }
}

/**
 * @description Method that display a section header with an
 * action button.
 *
 * @param {any} props
 */
const SectionHeader = props => {
    let hasButton = props.hasButton;
    if (hasButton === undefined) {
        hasButton = true;
    }
    let button;
    if (hasButton) {
        button = <Button
            onClick={() => props.action()}
            color="primary">
            {props.buttonTitle}
            <span className={`ml-2 oi ${props.buttonIcon}`}></span>
        </Button>;
    }
    return (
        <div className="d-flex justify-content-between align-items-center p-4">
            <h1 className="section-title">{props.title}</h1>
            {button}
        </div>
    );
};

export default SectionHeader;