function updateEntityModel(model: IEntityModel, {isNew,isDeleted}: {isNew?: boolean, isDeleted?:boolean}): void{
	if (model.__metadata == null) {
		model.__metadata = {
			isDeleted : false,
			isNew : false
		};
	}

	if (isNew != null) {
		model.__metadata.isNew = isNew;
	}
	if (isDeleted != null) {
		model.__metadata.isDeleted = isDeleted;
	}
}

export function isNew(model: IEntityModel):boolean{
	return model.__metadata == null || model.__metadata.isNew;
}

export function isDeleted(model: IEntityModel):boolean{
	return model.__metadata != null && model.__metadata.isDeleted;
}

export function setIsNew(model:IEntityModel):void{
	updateEntityModel(model, { isNew:true});
}

export function setIsDeleted(model:IEntityModel):void{
	updateEntityModel(model, { isDeleted:true});
}
