interface IEntityModel {
	readonly id?: string;
}

interface IUpdateableModel extends IEntityModel {
	readonly createdDate?: Date;
	readonly updatedDate?: Date;
}

interface IDashboardModel extends IUpdateableModel {
	name: string;
	readonly userId?: string;
}