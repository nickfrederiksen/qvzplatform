<template>
	<b-navbar toggleable="lg" type="dark" :sticky="true" variant="dark" class="flex-md-nowrap p-0 shadow">
		<b-navbar-brand class="col-md-3 col-lg-2 mr-0 px-3" to="/" exact>QVZ Portal</b-navbar-brand>

		<b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

		<b-collapse id="nav-collapse" is-nav>
			<b-navbar-nav>
				<b-nav-item href="#">Link</b-nav-item>
				<b-nav-item href="#" disabled>Disabled</b-nav-item>
			</b-navbar-nav>

			<!-- Right aligned nav items -->
			<b-navbar-nav class="ml-auto">
				<b-nav-item-dropdown right>
					<!-- Using 'button-content' slot -->
					<template v-slot:button-content>
						<em>User</em>
					</template>
					<b-dropdown-item href="#">Profile</b-dropdown-item>
					<b-dropdown-item href="#">Sign Out</b-dropdown-item>
				</b-nav-item-dropdown>
			</b-navbar-nav>
		</b-collapse>
	</b-navbar>
</template>

<style scoped>
.navbar-brand {
	padding-top: 0.75rem;
	padding-bottom: 0.75rem;
	font-size: 1rem;
	background-color: rgba(0, 0, 0, 0.25);
	box-shadow: inset -1px 0 0 rgba(0, 0, 0, 0.25);
}

.navbar .navbar-toggler {
	top: 0.25rem;
	right: 1rem;
}

.navbar .form-control {
	padding: 0.75rem 1rem;
	border-width: 0;
	border-radius: 0;
}

.form-control-dark {
	color: #fff;
	background-color: rgba(255, 255, 255, 0.1);
	border-color: rgba(255, 255, 255, 0.1);
}

.form-control-dark:focus {
	border-color: transparent;
	box-shadow: 0 0 0 3px rgba(255, 255, 255, 0.25);
}
</style>
