import Vue from 'vue'
import Component from 'vue-class-component'
import { apiStore } from '~/store'
import { Watch } from 'vue-property-decorator';

@Component({
	layout: "default"
})
export default class Dashboard extends Vue {
	mounted() {
		apiStore.loadDashboards();
	}

	public isEditMode = false;

	public get dashboards() {
		return apiStore.dashboards;
	}

	public get currentDashboard(): IDashboardModel {
		if (this.dashboards.length > 0) {
			return this.dashboards[0];
		} else {
			return {
				name: "Dashboardsss",
			};
		}
	}

	public toggleEditMode() {
		this.isEditMode = this.isEditMode === false;
	}
}