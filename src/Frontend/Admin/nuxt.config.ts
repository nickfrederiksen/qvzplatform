import fs from 'fs';
import path from 'path';
export default {
	mode: 'spa',
	env: {
		port: process.env.port,
		adTenantId: process.env.adTenantId,
		adClientId: process.env.adClientId,
		adScopes: process.env.adScopes,
		apiBaseUrl:process.env.apiBaseUrl
	},
	server: {
		port: process.env.port,
		timing: false,
		host: process.env.NODE_ENV == 'development' ? "localhost" : '0.0.0.0',
		https: process.env.NODE_ENV == 'development' ? {
			key: fs.readFileSync(path.resolve(__dirname, '../../../data/certificates/server.key')),
			cert: fs.readFileSync(path.resolve(__dirname, '../../../data/certificates/server.crt'))
		} : null,
	},
	/*
	** Headers of the page
	*/
	head: {
		title: process.env.npm_package_name || '',
		meta: [
			{ charset: 'utf-8' },
			{ name: 'viewport', content: 'width=device-width, initial-scale=1' },
			{ hid: 'description', name: 'description', content: process.env.npm_package_description || '' }
		],
		link: [
			{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
		]
	},
	router: {
		middleware: ["authenticated"]
	},
	/*
	** Customize the progress-bar color
	*/
	loading: { color: '#fff' },
	/*
	** Global CSS
	*/
	css: [
	],
	/*
	** Plugins to load before mounting the App
	*/
	plugins: [
		'@/plugins/msal',
		'@/plugins/apiAxios'
	],
	/*
	** Nuxt.js dev-modules
	*/
	buildModules: [
		'@nuxt/typescript-build'
	],
	/*
	** Nuxt.js modules
	*/
	modules: [
		// Doc: https://bootstrap-vue.js.org
		'bootstrap-vue/nuxt',
		// Doc: https://axios.nuxtjs.org/usage
		'@nuxtjs/axios',
		'@nuxtjs/pwa'
	],
	/*
	** Axios module configuration
	** See https://axios.nuxtjs.org/options
	*/
	axios: {
	},
	/*
	** Build configuration
	*/
	build: {
		/*
		** You can extend webpack config here
		*/
		extend(config, ctx) {
			console.log(ctx);
			if (ctx.isDev) {
				config.devtool = ctx.isClient ? 'source-map' : 'inline-source-map'
			}
		}
	}
}
