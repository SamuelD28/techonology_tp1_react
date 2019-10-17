import AnonymousCart from './services/anonymousCart'

var GlobalAppState = {};

GlobalAppState.Cart = new AnonymousCart();

export default GlobalAppState;