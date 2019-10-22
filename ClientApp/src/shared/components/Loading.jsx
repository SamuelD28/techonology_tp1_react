import React, { Component } from 'react';

/**
 * @description Statefull component that simulate a loading happening.
 * 
 **/
class Loading extends Component {

    /**
     * @description Constructor. Initiate the state.
     * 
     * @param {any} props
     */
    constructor(props) {
        super(props);
        this.state = { loading: true };
    }

    async componentDidMount() {
        await this.SimulateLoading();
    }

    /**
     *  @description Method that simulate the loading.
     **/
    SimulateLoading = async () => {
        await new Promise((resolve) => {
            setTimeout(async () => {
                await this.setState({ loading: false });
                resolve();
            }, this.props.secondsToWait * 1000)
        });
    }

    render() {
        return this.state.loading
            ? <div className="loader-container">
                <div className="loader loader-md"></div>
              </div>
            : this.props.children;
    }
};

export default Loading;