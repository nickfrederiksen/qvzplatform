import Vue from 'vue'
import Component from 'vue-class-component'
import { userStore } from '~/store';

@Component
export default class mainMenu extends Vue {

	public logout() {
		this.$msal.signOut();
	}

	public get userName() {
		return userStore.user.userName;
	}
}