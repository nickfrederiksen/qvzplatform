import { Vue, Component, Watch } from "vue-property-decorator";
import Logo from '~/components/Logo.vue'
import { userStore } from '~/store'

@Component({
	components: {
		Logo,
	},
	layout: "simple"
})
export default class Index extends Vue {
	beforeMount() {
		this.redirect();
	}

	@Watch("isAuthenticated")
	private redirect() {
		if (userStore.user.isAuthenticated) {
			this.$router.push({ path: "/dashboard" })
		}
	}

	public get isAuthenticated() {
		return userStore.user.isAuthenticated;
	}

}