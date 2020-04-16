import { api } from "~/clients/apiClient"

export function GetDashboards() {
	return api.get<IDashboardModel[]>("/admin/api/dashboards");
}