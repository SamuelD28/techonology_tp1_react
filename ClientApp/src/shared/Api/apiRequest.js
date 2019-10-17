import Routes from '../routes';
import Ajax from '../ajax';

class ApiRequest {
    GetAllItems = async () => {
        let data = await Ajax.GetData(Routes.api.menuItems.all);
        if (data.statusCode !== 200) {
            console.log(data.value.error);
            return null;
        }

        return data.value;
    }

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