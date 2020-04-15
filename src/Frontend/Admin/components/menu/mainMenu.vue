<template>
	<b-navbar toggleable="lg" type="dark" variant="dark" fixed="top" sticky="true" shadow>
		<b-navbar-brand href="#">QVZ Admin</b-navbar-brand>

		<b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

		<b-collapse id="nav-collapse" is-nav>
			<!-- Right aligned nav items -->
			<b-navbar-nav class="ml-auto">
				<b-nav-item-dropdown right>
					<!-- Using 'button-content' slot -->
					<template v-slot:button-content>
						<em>{{userName}}</em>
					</template>
					<b-dropdown-item @click="logout()">Sign Out</b-dropdown-item>
				</b-nav-item-dropdown>
			</b-navbar-nav>
		</b-collapse>
	</b-navbar>
</template>

<script src="./mainMenu.ts"></script>