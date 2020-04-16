import { Store } from 'vuex'
import { getModule } from 'vuex-module-decorators'
import userModule from '~/store/userModule'
import ApiModule from '~/store/apiModule'

let userStore: userModule
let apiStore: ApiModule;

function initialiseStores(store: Store<any>): void {
	userStore = getModule(userModule, store)
	apiStore = getModule(ApiModule, store);
}

export { initialiseStores, userStore, apiStore }