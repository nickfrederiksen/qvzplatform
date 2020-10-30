import { $axios } from "~/utils/api";
import { isNew } from "~/utils/stateManager";

export async function getRound(quiz:IQuizModel, id:string): Promise<IRoundModel>{
	const response = await $axios.get<IRoundModel>(`api/users/me/quizes/${quiz.id}/rounds/${id}`);

	return response.data;
}

export async function getRounds(quiz:IQuizModel): Promise<IRoundModel[]>{
	const response = await $axios.get<IRoundModel[]>(`api/users/me/quizes/${quiz.id}/rounds/`);

	return response.data;
}

export async function saveRound(quiz:IQuizModel, round:IRoundModel): Promise<IRoundModel>{
	if (isNew(round)) {
		const response = await $axios.post<IRoundModel>(`api/users/me/quizes/${quiz.id}/rounds`,round);
		return response.data;
	}
	else if(round.id != null) {
		await $axios.put<IQuizModel>(`api/users/me/quizes/${quiz.id}/rounds/${round.id}`,round);

		return getRound(quiz, round.id);
	}else{
		throw new Error("Unable to save quiz. No id was found.");
	}
}

export function deleteRound(quiz:IQuizModel, round:IRoundModel):Promise<unknown>{
	return $axios.delete(`api/users/me/quizes/${quiz.id}/rounds/${round.id}`);
}

export function deleteRounds(quiz:IQuizModel, rounds:IRoundModel[]): Promise<unknown>{
	const tasks: Promise<unknown>[] = [];
	rounds.forEach(round => {
		tasks.push(deleteRound(quiz,round));
	});

	return Promise.all(tasks);
}
