import { $axios } from "~/utils/api";
import { isNew } from "~/utils/stateManager";

export async function getQuizes(): Promise<IQuizModel[]>{
	const response = await $axios.get<IQuizModel[]>("api/users/me/quizes/");

	return response.data;
}

export async function getQuiz(id:string): Promise<IQuizModel>{
	const response = await $axios.get<IQuizModel>(`api/users/me/quizes/${id}`);

	return response.data;
}

export async function saveQuiz(quiz:IQuizModel): Promise<IQuizModel>{
	if (isNew(quiz)) {
		const response = await $axios.post<IQuizModel>("api/users/me/quizes",quiz);
		return response.data;
	}
	else if(quiz.id != null) {
		await $axios.put<IQuizModel>(`api/users/me/quizes/${quiz.id}`,quiz);

		return getQuiz(quiz.id);
	}else{
		throw new Error("Unable to save quiz. No id was found.");
	}

}
