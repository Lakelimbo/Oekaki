<script lang="ts">
	let { data } = $props();
</script>

<div class="mb-4 text-center text-lg text-muted-foreground">
	<h1 class="mb-2 text-3xl font-black text-foreground">Work in progress</h1>
	<p>Database connection and migrations have been resolved.</p>
	<p>Next: set up authentication</p>
</div>
<pre>{JSON.stringify(data, null, 2)}</pre>
