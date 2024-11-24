<script lang="ts">
	import * as Avatar from '$lib/components/ui/avatar';
	import type { components } from '$lib/data/openapi-schema-v1';

	let { nickname }: components['schemas']['UserProtectedDto'] = $props();

	const firstLetter = nickname?.substring(0, 1).toUpperCase() ?? '?';
</script>

<a href="/logout" class="block" data-sveltekit-preload-data={false} data-sveltekit-reload>
	<Avatar.Root>
		<Avatar.Fallback>{firstLetter}</Avatar.Fallback>
	</Avatar.Root>
</a>
