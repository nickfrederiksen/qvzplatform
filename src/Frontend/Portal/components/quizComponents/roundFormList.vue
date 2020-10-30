<template>
	<div>
		<b-form-group v-if="state.all.length > 0">
			<b-row>
				<b-col>
					<round-form v-for="round in visibleRounds" :key="round.id" :quiz="quiz" :round="round">
					</round-form>
				</b-col>
			</b-row>
		</b-form-group>
		<b-form-group>
			<b-row>
				<b-col>
					<b-button variant="secondary" @click="AddRound">Add round</b-button>
				</b-col>
			</b-row>
		</b-form-group>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Prop } from "vue-property-decorator";
import eventHub from "~/utils/eventHub";
import { isDeleted, isNew, setIsNew } from "~/utils/stateManager";
import { getRounds, deleteRounds } from "~/resources/roundResource";

@Component
export default class roundFormList extends Vue {
	@Prop()
	public quiz!: IQuizModel;

	public rounds: IRoundModel[] = [];

	public get visibleRounds() {
		return this.rounds.filter((r) => !isDeleted(r));
	}

	public get deletedRounds() {
		return this.rounds.filter((r) => isDeleted(r));
	}

	public async mounted() {
		if (!isNew(this.quiz)) {
			this.rounds = await getRounds(this.quiz);
		}

		eventHub.$on("quizSaved", (quiz: IQuizModel) => {
			if (this.quiz.id == quiz.id) {
				deleteRounds(this.quiz, this.deletedRounds);
			}
		});
	}

	public AddRound(): void {
		var newRound: IRoundModel = {
			name: "",
			sortOrder: 1,
			quizId: this.quiz.id,
		};
		setIsNew(newRound);

		this.rounds.push(newRound);
	}
}
</script>
