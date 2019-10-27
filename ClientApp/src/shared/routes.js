let domaine = "http://localhost:8870/";

/**
 * Api's routes
 * */
var Routes = {
    "domaine": domaine,
    "api": {
        "menuItems": {
            "all": domaine + 'api/menuitems',
            get: (id) => domaine + "api/menuitems/" + id,
        },
        "orders": {
            "all": domaine + 'api/Orders',
            get: (id) => domaine + "api/Orders/" + id,
            "post": domaine + "api/Orders",
            put: (id) => domaine + "api/Orders/" + id,
            delete: (id) => domaine + "api/Orders/" + id,
        }
    }
};

export default Routes;