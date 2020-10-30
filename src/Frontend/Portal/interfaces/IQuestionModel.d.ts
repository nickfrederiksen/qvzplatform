declare interface IQuestionModel extends IUserManagedModel {
	text:string;
	correctAnswer:string;
	points:number;
	typeId:string;
	roundId?:string;
}
