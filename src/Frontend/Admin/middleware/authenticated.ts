import { Middleware } from '@nuxt/types'

const myMiddleware: Middleware = (context) => {
	if (!context.app.$msal.isAuthenticated()) {
		context.app.$msal.signIn();
	}
}

export default myMiddleware