import React, { Component } from 'react';

class Loading extends Component {

    constructor(props) {
        super(props);
        this.state = { loading: true };
    }

    async componentDidMount() {
        await this.SimulateLoading();
    }

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
            ? <div className="loader">Loading...</div>
            : this.props.children;
    }
};

export default Loading;