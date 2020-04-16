import { AxiosInstance } from 'axios'
import { NuxtAxiosInstance } from '@nuxtjs/axios';
import { userStore } from '~/store';

let api: AxiosInstance

export function initializeAxios(axiosInstance: NuxtAxiosInstance) {

	api = axiosInstance.create({
		baseURL: process.env.apiBaseUrl,
	});

	api.interceptors.request.use((config) => {
		if (userStore.user.isAuthenticated) {
			config.headers.Authorization = `Bearer ${userStore.user.accessToken}`;
		}
		return config;
	});
}

export { api };