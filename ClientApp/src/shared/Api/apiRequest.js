import Routes from '../routes';
import Ajax from '../ajax';

class ApiRequest {
    getAllItems = async () => {
        let data = await Ajax.GetData(Routes.api.menuItems.all);
        if (data.statusCode !== 200) {
            console.log(data.value.error);
            return null;
        }

        return data.value;
    }

    Remove = (itemId, quantity) => {
        throw new Error("not implemented");
    }

    Clear = () => {
        throw new Error("not implemented");
    }

    Count = () => {
        throw new Error("not implemented");
    }

    GetItems = () => {
        throw new Error("not implemented");
    }

    GetItem = (itemId) => {
        throw new Error("not implemented");
    }
}

export default ApiRequest;