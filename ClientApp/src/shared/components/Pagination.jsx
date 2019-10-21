import React from 'react';
import { Button } from 'reactstrap';

/**
 * @description Staless component that handle the pagination navigation
 * of a list.
 * 
 * @param {any} props
 */
const Pagination = props => {

    /**
     * @description Method that display the pagination buttons
     * 
     **/
    const DisplayPaginationButtons = () => {
        return (
            <div className="d-flex section-bg">
                <Button
                    className="mr-auto"
                    hidden={props.previousQuery === null}
                    onClick={() => props.GetData(props.previousQuery)}
                    color="primary">
                    <span className="oi mr-2 oi-arrow-left"></span>
                    Précédent
                </Button>
                <Button
                    className="ml-auto"
                    hidden={props.nextQuery === null}
                    onClick={() => props.GetData(props.nextQuery)}
                    color="primary">
                    Suivant
                    <span className="oi ml-2 oi-arrow-right"></span>
                </Button>
            </div>
        );
    }

    /**
     * @description Method that display the current pagination
     * 
     **/
    const DisplayCurrentPagination = () => {
        let regex = /[0-9]+/gm;
        let res = props.currentQuery.match(regex);
        return <div className="text-white">{res[0]} à {res[1]}</div>
    }

    return (
        <div className={`text-center p-4 ${props.className || ""}`}>
            {DisplayCurrentPagination()}
            {DisplayPaginationButtons()}
        </div>
    );
};

export default Pagination;