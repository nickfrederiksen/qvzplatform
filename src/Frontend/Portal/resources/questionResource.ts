import { $axios } from "~/utils/api";
import { isNew } from "~/utils/stateManager";


export async function getQuestion(quiz:IQuizModel, round:IRoundModel, id:string): Promise<IRoundModel>{
	const response = await $axios.get<IRoundModel>(`api/users/me/quizes/${quiz.id}/rounds/${round.id}/questions/${id}`);

	return response.data;
}

export async function saveQuestion(quiz:IQuizModel, round:IRoundModel, question:IQuestionModel): Promise<IRoundModel>{
	if (isNew(question)) {
		const response = await $axios.post<IRoundModel>(`api/users/me/quizes/${quiz.id}/rounds/${round.id}/questions`,question);
		return response.data;
	}
	else if(question.id != null) {
		await $axios.put<IQuizModel>(`api/users/me/quizes/${quiz.id}/rounds/${round.id}/questions/${question.id}`,question);

		return getQuestion(quiz, round,question.id);
	}else{
		throw new Error("Unable to save quiz. No id was found.");
	}
}

export async function getQuestions(quiz:IQuizModel, round:IRoundModel): Promise<IQuestionModel[]>{
	const response = await $axios.get<IQuestionModel[]>(`api/users/me/quizes/${quiz.id}/rounds/${round.id}/questions`);

	return response.data;
}

export async function deleteQuestions(quiz:IQuizModel, round:IRoundModel, questions:IQuestionModel[]): Promise<unknown>{
	const tasks: Promise<unknown>[] = [];

	questions.forEach(question => {
		tasks.push($axios.delete(`api/users/me/quizes/${quiz.id}/rounds/${round.id}/questions/${question.id}`));
	});

	return Promise.all(tasks);
}
