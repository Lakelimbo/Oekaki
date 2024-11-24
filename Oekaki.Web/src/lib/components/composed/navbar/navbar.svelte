<script lang="ts">
	import type { components } from '$lib/data/openapi-schema-v1';
	import { BrandElement } from '../brand';
	import { ThemeToggle } from '../theme-toggle';
	import NavbarLoggedIn from './navbar-logged-in.svelte';
	import NavbarLoggedOut from './navbar-logged-out.svelte';

	type Props = {
		user?: components['schemas']['InfoResponse'];
	};

	let { user }: Props = $props();
</script>

<header class="sticky top-0 bg-background">
	<nav class="container flex items-center justify-between gap-2 py-4">
		<BrandElement href="/" />
		<div class="flex-1"></div>
		<ThemeToggle />
		{#if user}
			<NavbarLoggedIn {...user} />
		{:else}
			<NavbarLoggedOut />
		{/if}
	</nav>
</header>
