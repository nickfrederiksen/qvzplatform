<template>
	<div>
		<div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3">
			<div>
				<input type="text" v-if="isEditMode" v-model="currentDashboard.name" />
				<h1 v-else>{{currentDashboard.name}}</h1>
			</div>

			<b-button-toolbar aria-label="Dashboard toolbar">
				<b-button-group size="sm" class="mx-1">
					<b-button>New</b-button>
					<b-button @click="toggleEditMode()">Edit</b-button>
					<b-button>Undo</b-button>
				</b-button-group>
				<b-dropdown size="sm" class="mx-1" right text="menu" v-if="dashboards.length > 1">
					<b-dropdown-item v-for="item in dashboards" :key="item.id">Item 1</b-dropdown-item>
				</b-dropdown>
				<b-button-group size="sm" class="mx-1">
					<b-button>Save</b-button>
					<b-button>Cancel</b-button>
				</b-button-group>
			</b-button-toolbar>
		</div>
	</div>
</template>
<script src="./dashboard.ts"></script>