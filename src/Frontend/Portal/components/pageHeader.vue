<template>
	<div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
		<h1 class="h2">{{header}}</h1>
		<slot />
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import { Prop } from "vue-property-decorator";

@Component
export default class pageHeader extends Vue {
	@Prop()
	public header!: string;
}
</script>
