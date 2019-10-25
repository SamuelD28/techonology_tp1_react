import AnonymousCart from './services/anonymousCart'

class GlobalAppStateSingleton{
    _subscribers = [];

    state = {
        cart: new AnonymousCart()
    };

    setState = (state) => {
        this.state = state;
        this._TriggerEvent();
    }

    SubscribeStateChange = (callback) => {
        this._subscribers.push(callback);
    }

    _TriggerEvent = () => {
        console.log('Global States: changed');
        for (let i = 0; i < this._subscribers.length; i++) {
            this._subscribers[i](this.state);
        }
    }
};

const GlobalAppState = new GlobalAppStateSingleton();

export default GlobalAppState;