import Vue from 'vue'
import Component from 'vue-class-component'
import { IUserModel, IUserState } from '~/store/userStore';

@Component
export default class mainMenu extends Vue{

	public logout (){
		console.log(this.$store);
		this.$msal.signOut();
	}

	public get userName(){
		const userState = this.$store.state.userStore as IUserState;
		return userState.user.userName;
	}
}