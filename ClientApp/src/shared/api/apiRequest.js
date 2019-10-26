import Routes from '../routes';
import Ajax from '../ajax';

/**
 * Class used to make all api's request
 */
class ApiRequest {
    /**
     * Get all items asynchronously. If something went wrong with the request, it returns null, else it returns array of items
     * 
     * @returns {Array|null}
     */
    GetAllItems = async () => {
        let data = await Ajax.GetData(Routes.api.menuItems.all);
        if (data.statusCode < 200 || data.statusCode > 399) {
            console.log(data.value.error);
            return null;
        }

        return data.value;
    }

    /**
     * Get an item asynchronously. If something went wrong with the request, it returns null, else it returns the item
     * 
     * @param {int} itemId Item's id
     * @returns {any|null} items
     */
    GetItem = async (itemId) => {
        let data = await Ajax.GetData(Routes.api.menuItems.get(itemId));
        if (data.statusCode !== 200) {
            console.log(data.value.error);
            return null;
        }

        return data.value;
    }
}

export default ApiRequest;