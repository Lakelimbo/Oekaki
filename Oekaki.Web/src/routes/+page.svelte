<script lang="ts">
	let { data } = $props();
</script>

<div class="text-muted-foreground mb-4 text-center text-lg">
	<h1 class="text-foreground mb-2 text-3xl font-black">Work in progress</h1>
	<p>Database connection and migrations have been resolved.</p>
	<p>Next: set up authentication</p>
</div>
<pre>{JSON.stringify(data, null, 2)}</pre>
