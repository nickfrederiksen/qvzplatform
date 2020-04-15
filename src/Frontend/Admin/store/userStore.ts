import Vue from 'vue';
import Vuex from 'vuex';
import { MSALBasic } from 'vue-msal/lib/src/types';

export const state=()=>({
	user: {
		isAuthenticated: false,
	}
})

export const mutations = {
	updateUser: (state, user: IUserModel) => {
		console.log("mutate before", state.user);
		state.user = user;
		console.log("mutate after", state.user);
	}
};

export const actions ={
	updateUser: (context, user: IUserModel) => {
		context.commit("updateUser", user);
	}
};

export interface IUserState {
	user: IUserModel;
}

export interface IUserModel {
	isAuthenticated: boolean;
	userName?: string;
}