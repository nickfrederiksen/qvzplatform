<template>
	<b-card no-body>
		<b-card-header header-tag="header">
			<b-row>
				<b-col>
					<b-form-input v-model="round.name" placeholder="Enter name of the round. Eg. Round 1!"></b-form-input>
				</b-col>
				<b-col>
					<b-button variant="outline-danger" @click="RemoveRound()">Remove round</b-button>
				</b-col>
			</b-row>
		</b-card-header>
		<b-card-body>
			<question-form-list :round="round" :quiz="quiz" />
		</b-card-body>
	</b-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Prop } from "vue-property-decorator";
import { setIsDeleted } from "~/utils/stateManager";
import eventHub from "~/utils/eventHub";
import { saveRound } from "~/resources/roundResource";

@Component
export default class roundForm extends Vue {
	@Prop()
	public round!: IRoundModel;

	@Prop()
	public quiz!: IQuizModel;

	public mounted() {
		eventHub.$on("quizSaved", (quiz: IQuizModel) => {
			if (this.quiz.id === quiz.id) {
				console.debug(`Saving round: ${quiz.id} -> ${this.round.name}`);
				saveRound(quiz, this.round).then((round) => {
					this.round.id == round.id;
					eventHub.$emit("roundSaved", { quiz, round });
				});
			}
		});
	}

	public RemoveRound(): void {
		setIsDeleted(this.round);
	}
}
</script>
