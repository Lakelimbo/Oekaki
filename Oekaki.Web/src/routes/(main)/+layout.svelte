<script lang="ts">
	import { Navbar } from '$lib/components/composed/navbar';

	let { data, children } = $props();
</script>

<Navbar user={data.user} />
<div class="container mt-6 flex-1">
	{@render children()}
</div>
