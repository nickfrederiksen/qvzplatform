<template>
	<div>
		<portal-menu />
		<b-container fluid="">
			<b-row>
				<side-bar />
				<main class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
					<Nuxt />
				</main>
			</b-row>
		</b-container>
	</div>
</template>
