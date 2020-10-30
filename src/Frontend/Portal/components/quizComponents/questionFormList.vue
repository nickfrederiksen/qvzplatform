<template>
	<div>
		<b-form-group v-if="state.all.length > 0">
			<b-row>
				<b-col>
					<question-form v-for="question in rounds" :key="question.id" :question="question" :quiz="quiz" :round="round">
					</question-form>
				</b-col>
			</b-row>
		</b-form-group>
		<b-form-group>
			<b-row>
				<b-col>
					<b-button variant="secondary" @click="AddQuestion">Add question</b-button>
				</b-col>
			</b-row>
		</b-form-group>
	</div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import {
	getQuestions,
	deleteQuestions,
} from "~/resources/questionResource";
import eventHub from "~/utils/eventHub";
import { isDeleted, isNew, setIsNew } from "~/utils/stateManager";

@Component
export default class questionFormList extends Vue {
	@Prop()
	public round!: IRoundModel;

	@Prop()
	public quiz!: IQuizModel;

	public questions: IQuestionModel[] = [];

	public get visibleQuestions() {
		return this.questions.filter((q) => !isDeleted(q));
	}

	public get deletedQuestions() {
		return this.questions.filter((q) => isDeleted(q));
	}

	public async mounted() {
		if (!isNew(this.round)) {
			this.questions = await getQuestions(this.quiz, this.round);
		}

		eventHub.$on(
			"roundSaved",
			({ quiz, round }: { quiz: IQuizModel; round: IRoundModel }) => {
				if (this.quiz == quiz && this.round == round) {
					deleteQuestions(quiz, round, this.deletedQuestions);
				}
			}
		);
	}

	public AddQuestion(): void {
		const question: IQuestionModel = {
			text: "",
			correctAnswer: "",
			points: 0,
			typeId: "",
			roundId: this.round.id,
		};

		setIsNew(question);
		this.questions.push(question);
	}
}
</script>
