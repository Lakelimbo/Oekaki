<script lang="ts">
	import '@fontsource-variable/inter';
	import '../app.pcss';
	import { Navbar } from '$lib/components/composed/navbar';
	import { ModeWatcher } from 'mode-watcher';

	let { children } = $props();
</script>

<ModeWatcher />
<Navbar />
<div class="container mt-6 flex-1">
	{@render children()}
</div>
