<template>
	<div>
		<mainMenu />
		<div class="container-fluid">
			<div class="row">
				<sidebar></sidebar>
				<div class="col-10 offset-2">
					<main>
						<nuxt />
					</main>
				</div>
			</div>
		</div>
	</div>
</template>
<script src="./default.ts"></script>