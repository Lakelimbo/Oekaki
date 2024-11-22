<script lang="ts">
	import * as Avatar from '$lib/components/ui/avatar';
	import type { components } from '$lib/data/openapi-schema-v1';

	let { email }: components['schemas']['InfoResponse'] = $props();

	const firstLetter = email?.substring(0, 1).toUpperCase() ?? '?';
</script>

<a href="/logout" class="block">
	<Avatar.Root>
		<Avatar.Fallback>{firstLetter}</Avatar.Fallback>
	</Avatar.Root>
</a>
