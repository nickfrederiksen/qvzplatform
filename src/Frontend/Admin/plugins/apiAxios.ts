import axios, { NuxtAxiosInstance } from "@nuxtjs/axios";
import { Plugin } from '@nuxt/types'
import { initializeAxios } from "~/clients/apiClient";

declare module '@nuxt/types' {
	interface NuxtAppOptions {
		$apiAxios: NuxtAxiosInstance,
	}
}
declare module 'vue/types/vue' {
	interface Vue {
		$apiAxios: NuxtAxiosInstance,
	}
}

const axiosPlugin: Plugin = (context, inject) => {
	initializeAxios(context.$axios)
}

export default axiosPlugin;