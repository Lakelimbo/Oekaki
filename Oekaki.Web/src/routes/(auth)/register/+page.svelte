<script lang="ts">
	import Form from './form.svelte';

	let { data } = $props();
</script>

<Form form={data.form} />
