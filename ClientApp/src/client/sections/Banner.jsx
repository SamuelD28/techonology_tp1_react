import React from 'react';

const Banner = props => (
    <section className="home-slider owl-carousel img" style={{ backgroundImage: `url('img/bg_1.jpg')` }} >
        <div className="slider-item">
            <div className="overlay"></div>
            <div className="container">
                <div className="row slider-text align-items-center" data-scrollax-parent="true">
                    <div className="col-md-6 col-sm-12 ftco-animate">
                        <span className="subheading">Delicious</span>
                        <h1 className="mb-4">Italian Cuizine</h1>
                        <p className="mb-4 mb-md-5">A small river named Duden flows by their place and supplies it with the necessary regelialia.</p>
                        <p><a href="#" className="btn btn-primary p-3 px-xl-4 py-xl-3">Order Now</a> <a href="#" className="btn btn-white btn-outline-white p-3 px-xl-4 py-xl-3">View Menu</a></p>
                    </div>
                    <div className="col-md-6 ftco-animate">
                        <img src="images/bg_1.png" className="img-fluid" alt="" />
                    </div>
                </div>
            </div>
        </div>
    </section>
);

export default Banner;
