<template>
	<div id="sidebar" class="col-2 border-right">
		<nav>
			<b-nav vertical class="w-25">
				<b-nav-item active>Active</b-nav-item>
				<b-nav-item>Link</b-nav-item>
				<b-nav-item>Another Link</b-nav-item>
				<b-nav-item disabled>Disabled</b-nav-item>
			</b-nav>
		</nav>
	</div>
</template>

<script src="./sidebar.ts"></script>
<style lang="scss">
#sidebar {
	top: 56px;
	z-index: 1019;
	position:fixed;
	bottom: 0;
}
</style>