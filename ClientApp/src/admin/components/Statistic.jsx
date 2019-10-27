import React, { Component } from 'react'
import { Bar } from 'react-chartjs-2';
import SectionHeader from '../../shared/components/SectionHeader';

export default class Statistic extends Component {

    constructor(props) {
        super(props);

        this.data = {
            datasets: []
        };
        this.dataset = {
            backgroundColor: 'rgba(250, 197, 100, 1)',
        };
    }

    render() {
        this.data.labels = this.props.labels;
        this.dataset.data = this.props.data;
        this.dataset.label = this.props.label;
        this.data.datasets.push(this.dataset);

        return (
            <section className={`${this.props.className}`}>
                <SectionHeader title={this.props.title} className="h-20 text-sm" />
                <div className="p-4 bg-dark h-80">
                    <Bar data={this.data} />
                </div>
            </section>
        )
    }
}
