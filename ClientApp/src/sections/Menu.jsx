﻿import React from 'react';

const Menu = props => (
    <section>
        <div class="container">
            <div class="row justify-content-center mb-5 pb-3">
                <div class="col-md-7 heading-section text-center">
                    <h2 class="mb-4">Hot Pizza Meals</h2>
                    <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</p>
                </div>
            </div>
        </div>
        <div class="container-wrap">
            <div class="row no-gutters d-flex">
                <div class="col-lg-4 d-flex">
                    <div class="services-wrap d-flex">
                        <a href="#" class="img" style={{ backgroundImage: `url('images/pizza-1.jpg')` }}></a>
                        <div class="text p-4">
                            <h3>Italian Pizza</h3>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia </p>
                            <p class="price"><span>$2.90</span> <a href="#" class="ml-2 btn btn-white btn-outline-white">Order</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 d-flex">
                    <div class="services-wrap d-flex">
                        <a href="#" class="img" style={{ backgroundImage: `url('images/pizza-2.jpg')` }}></a>
                        <div class="text p-4">
                            <h3>Greek Pizza</h3>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia</p>
                            <p class="price"><span>$2.90</span> <a href="#" class="ml-2 btn btn-white btn-outline-white">Order</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 d-flex">
                    <div class="services-wrap d-flex">
                        <a href="#" class="img" style={{ backgroundImage: `url('images/pizza-3.jpg')` }}></a>
                        <div class="text p-4">
                            <h3>Caucasian Pizza</h3>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia</p>
                            <p class="price"><span>$2.90</span> <a href="#" class="ml-2 btn btn-white btn-outline-white">Order</a></p>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 d-flex">
                    <div class="services-wrap d-flex">
                        <a href="#" class="img order-lg-last" style={{ backgroundImage: `url('images/pizza-4.jpg')` }}></a>
                        <div class="text p-4">
                            <h3>American Pizza</h3>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia </p>
                            <p class="price"><span>$2.90</span> <a href="#" class="ml-2 btn btn-white btn-outline-white">Order</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 d-flex">
                    <div class="services-wrap d-flex">
                        <a href="#" class="img order-lg-last" style={{ backgroundImage: `url('images/pizza-5.jpg')` }}></a>
                        <div class="text p-4">
                            <h3>Tomatoe Pie</h3>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia</p>
                            <p class="price"><span>$2.90</span> <a href="#" class="ml-2 btn btn-white btn-outline-white">Order</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 d-flex">
                    <div class="services-wrap d-flex">
                        <a href="#" class="img order-lg-last" style={{ backgroundImage: `url('images/pizza-6.jpg')` }}></a>
                        <div class="text p-4">
                            <h3>Margherita</h3>
                            <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia</p>
                            <p class="price"><span>$2.90</span> <a href="#" class="ml-2 btn btn-white btn-outline-white">Order</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
);

export default Menu;
