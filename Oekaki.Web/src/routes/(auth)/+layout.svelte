<script lang="ts">
	import { BrandElement } from '$lib/components/composed/brand';
	import { ThemeToggle } from '$lib/components/composed/theme-toggle';
	import { Button } from '$lib/components/ui/button';

	let { children } = $props();
</script>

<div class="flex min-h-screen flex-col justify-center gap-4 p-6 md:flex-row">
	<main class="place-content-center md:order-1 md:min-w-80 md:max-w-[375px]">
		<BrandElement href="/" class="mb-2 justify-center" />
		{@render children()}
	</main>
	<aside
		class="sticky top-6 flex h-full w-full items-end rounded-xl bg-card p-4 md:min-h-[94.75vh] md:w-auto md:flex-1"
	>
		<nav class="flex w-full items-center justify-center gap-2 md:justify-start">
			<ThemeToggle class="hover:bg-background" />
			<Button href="/privacy" variant="link">Privacy Policy</Button>
		</nav>
	</aside>
</div>
