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
        }
    }
};

export default Routes;