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
        }
    }
};

export default Routes;