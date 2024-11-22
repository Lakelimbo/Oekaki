<script lang="ts">
	import { Button } from '$lib/components/ui/button';
	import { toggleMode } from 'mode-watcher';
	import Sun from 'lucide-svelte/icons/sun';
	import Moon from 'lucide-svelte/icons/moon';

	type Props = {
		class?: string;
	};

	let { class: className }: Props = $props();
</script>

<Button onclick={toggleMode} variant="ghost" size="icon" class={className}>
	<Sun class="rotate-0 scale-125 fill-foreground transition-all dark:-rotate-90 dark:scale-0" />
	<Moon
		class="absolute rotate-90 scale-0 fill-foreground transition-all dark:rotate-0 dark:scale-125"
	/>
	<span class="sr-only">Toggle theme</span>
</Button>
