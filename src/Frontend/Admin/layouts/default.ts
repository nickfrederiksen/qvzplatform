import Vue from 'vue'
import Component from 'vue-class-component'
import mainMenu from "~/components/menu/mainMenu";
import sidebar from "~/components/menu/sidebar";

@Component({
	components: {
		mainMenu,
		sidebar
	}
})
export default class defaultLayout extends Vue {

}