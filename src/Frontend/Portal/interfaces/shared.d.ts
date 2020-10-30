declare interface IEntityMetadata{
	isNew:boolean;
	isDeleted:boolean;
}

declare interface IEntityModel{
	id?:string;

	// eslint-disable-next-line @typescript-eslint/naming-convention
	__metadata?:IEntityMetadata;
}

declare interface IUpdateableModel extends IEntityModel{
	createdDate?:Date;
	updatedDate?:Date;
}

declare interface IUserManagedModel extends IUpdateableModel{
	createdById?:string;
	updatedById?:string;
}
