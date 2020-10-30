<template>
	<b-form @submit.stop.prevent="onSubmit">
		<b-form-group label="Name" label-for="name" description="The awesome name of the quiz.">
			<b-form-input id="name" v-model="quiz.name" required placeholder="Enter a name for your quiz." />
		</b-form-group>
		<b-form-group label="Time" label-for="date" description="The date and time when the quiz is being held.">
			<b-row>
				<b-col>
					<b-form-datepicker v-model="datePart" @input="onDateChange" :min="new Date()" start-weekday="1" id="date" class="mb-2"></b-form-datepicker>
				</b-col>
				<b-col>
					<b-form-timepicker v-model="timePart" @input="onDateChange"></b-form-timepicker>
				</b-col>
			</b-row>
		</b-form-group>

		<b-form-group>
			<round-form-list :quiz="quiz" />
		</b-form-group>

		<b-form-group>
			<b-row>
				<b-col>
					<b-button variant="primary" type="submit">Save</b-button>
				</b-col>
			</b-row>
		</b-form-group>
	</b-form>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { saveQuiz } from "~/resources/quizResource";
import eventHub from "~/utils/eventHub";

@Component
export default class quizForm extends Vue {
	@Prop({ required: false })
	public quizId?: string;

	public datePart: string = "";
	public timePart: string = "";

	public quiz: IQuizModel = {
		name: "",
		date: new Date(),
	};

	public mounted() {
		if (this.quizId != null) {
			// TODO: Load quiz.
		}

		var date = this.quiz.date;
		const paddedMonth = this.padValue(date.getMonth());
		const paddedDate = this.padValue(date.getDate());
		const paddedHour = this.padValue(date.getHours());
		const paddedMinute = this.padValue(date.getMinutes());

		this.datePart = `${date.getFullYear()}-${paddedMonth}-${paddedDate}`;
		this.timePart = `${paddedHour}-${paddedMinute}-00`;
	}

	private padValue(value: number): string {
		if (value > -10 && value < 10) {
			return `0${value}`;
		} else {
			return value + "";
		}
	}

	public onDateChange() {
		this.quiz.date = new Date(`${this.datePart} ${this.timePart}`);
	}

	public onSubmit() {
		console.debug(`Saving quiz: ${this.quiz.name}`);
		saveQuiz(this.quiz).then((quiz) => {
			this.quiz.id == quiz.id;
			eventHub.$emit("quizSaved", quiz);
		});
	}
}
</script>
