<script lang="ts">
	import { Button } from '$lib/components/ui/button';
	import { toggleMode } from 'mode-watcher';
	import Sun from 'lucide-svelte/icons/sun';
	import Moon from 'lucide-svelte/icons/moon';
</script>

<Button onclick={toggleMode} variant="ghost" size="icon">
	<Sun class="fill-foreground rotate-0 scale-125 transition-all dark:-rotate-90 dark:scale-0" />
	<Moon
		class="fill-foreground absolute rotate-90 scale-0 transition-all dark:rotate-0 dark:scale-125"
	/>
	<span class="sr-only">Toggle theme</span>
</Button>
