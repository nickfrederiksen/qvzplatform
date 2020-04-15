import Vue from 'vue'; //import Vue if you want to use the framework.globalMixin option
import MSAL from 'vue-msal/lib/plugin';

import { Plugin } from '@nuxt/types'
import { MSALBasic, DataObject } from 'vue-msal/lib/src/types';
import { IUserModel } from '~/store/userStore';

declare module '@nuxt/types' {
	interface NuxtAppOptions {
		$msal: MSALBasic,
	}
}
declare module 'vue/types/vue' {
	interface Vue {
		$msal: MSALBasic,
	}
}

const myPlugin: Plugin = (context, inject) => {

	inject('msal', new MSAL(
		{
			auth: {
				clientId: '9709edb4-1362-49d2-9630-9c345e2fbc54',
				tenantId: "431326c9-9144-4c33-9db1-76a761883b2e",
				onAuthentication: (ctx, error, response) => {
					const user: IUserModel = {
						isAuthenticated: false,
					};

					context.store.dispatch("userStore/updateUser", user);
				},
				onToken: (ctx, error, response) => {
					const msal = ctx as MSALBasic;
					const user: IUserModel = {
						isAuthenticated: msal.isAuthenticated(),
					};
					if (user.isAuthenticated) {
						const msalUser = msal.data.user as any;
						user.userName = msalUser.name;
					}

					context.store.dispatch("userStore/updateUser", user);
				},
				beforeSignOut: (ctx) => {
					const user: IUserModel = {
						isAuthenticated: false,
					};

					context.store.dispatch("userStore/updateUser", user);
				}
			}
		}, Vue /* [optional] should be passed as an argument if you want to the framework.globalMixin option*/
	))
}

export default myPlugin