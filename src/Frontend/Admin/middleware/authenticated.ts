import { Middleware } from '@nuxt/types'

const myMiddleware: Middleware = (context) => {
	if (!context.app.$msal.isAuthenticated() && context.route.name !== 'login') {
		context.app.$msal.signIn();
	  }
}

export default myMiddleware