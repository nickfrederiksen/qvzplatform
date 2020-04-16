
import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators';
import { MSALBasic } from 'vue-msal/lib/src/types';

@Module({
	name: "userModule",
	stateFactory: true,
	namespaced: true,
})
export default class UserModule extends VuexModule {
	user: IUserModel = {
		isAuthenticated: false,
	};

	@Mutation
	updateUserState(user: IUserModel) {
		this.user = user;
	}

	@Action
	siginUser(msal:MSALBasic) {
		const user: IUserModel = {
			isAuthenticated: msal.isAuthenticated(),
		};
		if (user.isAuthenticated) {
			const msalUser = msal.data.user as any;

			user.userName = msalUser.name;
			user.accessToken = msal.data.accessToken;
		}

		this.updateUserState(user);
	}

	@Action
	sigoutUser() {
		this.updateUserState({isAuthenticated:false});
	}
}

export interface IUserModel {
	isAuthenticated: boolean;
	userName?: string;
	accessToken?: string;
}