let domaine = "http://localhost:8870/";

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