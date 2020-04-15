import Vue from 'vue'
import Component from 'vue-class-component'
import { IUserState } from '~/store/userStore';

@Component
export default class mainMenu extends Vue {

	public logout() {
		this.$msal.signOut();
	}

	public get userName() {
		const userState = this.$store.state.userStore as IUserState;
		return userState.user.userName;
	}
}