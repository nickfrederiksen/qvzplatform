import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators';
import { GetDashboards } from '~/clients/resources/dashboardResource';
import { userStore } from '.';


@Module({
	name: "apiModule",
	stateFactory: true,
	namespaced: true,
})
export default class ApiModule extends VuexModule {
	dashboards: IDashboardModel[] = [];

	@Mutation
	setDashboards(dashboards: IDashboardModel[]) {
		this.dashboards = dashboards;
	}

	@Action
	async loadDashboards() {
		console.log("test");
		if (userStore.user.isAuthenticated) {
			const dashboardReponse = await GetDashboards();
			this.setDashboards(dashboardReponse.data);
		} else {
			this.setDashboards([]);
		}
	}
}