/**
 * Api's routes
 * */
var Routes = {
    "api": {
        "menuItems": {
            "all": '/api/menuitems',
            get: (id) => "/api/menuitems/" + id,
        },
        "orders": {
            "all": '/api/Orders',
            get: (id) => "/api/Orders/" + id,
            "post": "/api/Orders",
            put: (id) => "/api/Orders/" + id,
            delete: (id) => "/api/Orders/" + id,
        },
        "deliveryMan": {
            "all": '/api/deliverymen'
        }
    }
};

export default Routes;