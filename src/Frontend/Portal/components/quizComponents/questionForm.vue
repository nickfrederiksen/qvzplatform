<template>
	<div>
		<b-form-group label="Question" label-for="question" description="The awesome question.">
			<b-form-input id="question" v-model="question.text" required placeholder="Enter a question." />
			<b-button variant="outline-danger" @click="RemoveQuestion()">Remove question</b-button>
		</b-form-group>
		<b-form-group label="Answer" label-for="question" description="The awesome question.">
			<b-form-input id="question" v-model="question.correctAnswer" required placeholder="Enter a question." />
		</b-form-group>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Prop } from "vue-property-decorator";
import { setIsDeleted } from "~/utils/stateManager";
import eventHub from "~/utils/eventHub";
import { saveQuestion } from "~/resources/questionResource";

@Component
export default class questionForm extends Vue {
	@Prop()
	public question!: IQuestionModel;

	@Prop()
	public round!: IRoundModel;

	@Prop()
	public quiz!: IQuizModel;

	public mounted() {
		eventHub.$on(
			"roundSaved",
			({ quiz, round }: { quiz: IQuizModel; round: IRoundModel }) => {
				if (this.quiz.id === quiz.id && this.round.id == round.id) {
					console.debug(
						`Saving question: ${quiz.id} -> ${round.id} -> ${this.question.text}`
					);
					saveQuestion(quiz, round, this.question).then(
						(question) => {
							this.question.id == question.id;
							eventHub.$emit("questionSaved", {
								quiz,
								round,
								question,
							});
						}
					);
				}
			}
		);
	}

	public RemoveQuestion(): void {
		setIsDeleted(this.question);
	}
}
</script>
