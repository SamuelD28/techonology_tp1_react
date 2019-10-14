import React from 'react';
import MenuItem from '../components/MenuItem';

class MenuSection extends React.Component {

    constructor(props) {
        super(props);

        this.state = [
            {
                name: "Italian Pizza",
                img: "images/pizza-1.jpg",
                description: "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia ",
                price: 3.25
            },
            {
                name: "Greek Pizza",
                img: "images/pizza-2.jpg",
                description: "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia ",
                price: 3.25
            },
            {
                name: "Caucassian Pizza",
                img: "images/pizza-3.jpg",
                description: "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia ",
                price: 3.25
            },
            {
                name: "Margeritta Pizza",
                img: "images/pizza-4.jpg",
                description: "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia ",
                price: 3.25
            },
            {
                name: "Spicy Pizza",
                img: "images/pizza-5.jpg",
                description: "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia ",
                price: 3.25
            },
            {
                name: "Sweet Pizza",
                img: "images/pizza-6.jpg",
                description: "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia ",
                price: 3.25
            },
        ];
    }

    DisplayMenuItems = () => {
        return this.state.map((menuItem, index) => (
            <MenuItem
                key={index}
                inverted={index > (this.state.length / 2) - 1}
                name={menuItem.name}
                img={menuItem.img}
                description={menuItem.description}
                price={menuItem.price}
            />
        ));
    }

    render() {
        return (
            <section>
                <div className="container">
                    <div className="row justify-content-center mb-5 pb-3">
                        <div className="col-md-7 heading-section text-center">
                            <h2 className="mb-4">Hot Pizza Meals</h2>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</p>
                        </div>
                    </div>
                </div>
                <div className="container-wrap">
                    <div className="row no-gutters d-flex">
                        {this.DisplayMenuItems()}
                    </div>
                </div>
            </section >
        )
    }
}

export default MenuSection;
