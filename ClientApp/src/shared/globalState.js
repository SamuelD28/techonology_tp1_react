import AnonymousCart from './services/anonymousCart'

/**
 * Globale state of this application
 */
class GlobalAppStateSingleton {
    _subscribers = [];

    /**
     * State
     */
    state = {
        cart: new AnonymousCart()
    };

    /**
     * Change the app's state and notify the subscribers
     * 
     * @param {any} state New state
     */
    setState = (state) => {
        this.state = state;
        this._TriggerEvent();
    }

    /**
    * Subscribe to the state changed event
    *
    * @param {GlobalAppStateSingleton~StateChangeCallback} callback Callback
    */
    SubscribeStateChange = (callback) => {
        this._subscribers.push(callback);
    }

    _TriggerEvent = () => {
        console.log('Global States: changed');
        for (let i = 0; i < this._subscribers.length; i++) {
            this._subscribers[i](this.state);
        }
    }


    /**
    * Global state changed event callback
    * @callback GlobalAppStateSingleton~StateChangeCallback
    * @param {any} state New state
    */
};

const GlobalAppState = new GlobalAppStateSingleton();



export default GlobalAppState;