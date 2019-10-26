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
        if (data === undefined || data.statusCode < 200 || data.statusCode > 399) {
            this.LogError(data);
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
        if (data === undefined || data.statusCode < 200 || data.statusCode > 399) {
            this.LogError(data);
            return null;
        }

        return data.value;
    }

/**
 * Create an order
 *
 * @param {any} data order's data
 * @returns {any|null} order's data or null if it failed
 */
    MakeOrder = async (data) => {
        console.log(data);
        let response = await Ajax.PostData(Routes.api.orders.post, data);
        if (response === undefined || response.statusCode < 200 || response.statusCode > 399) {
            this.LogError(response);
            return null;
        }

        return response.value;
    }

    LogError = (response) => {
        console.log((response || { value: { error: 'An error occured during the proccess' } }).value.error);
    }
}

export default ApiRequest;