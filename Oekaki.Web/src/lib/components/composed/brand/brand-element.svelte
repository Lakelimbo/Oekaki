<script lang="ts">
	import { cn } from '$lib/utils/style';
	import type { WithElementRef } from 'bits-ui';
	import type { HTMLAnchorAttributes, HTMLButtonAttributes } from 'svelte/elements';
	import { BrandLogo, BrandWordmark } from '.';

	type Props = WithElementRef<HTMLAnchorAttributes> & WithElementRef<HTMLButtonAttributes>;

	let { class: className, href, ...restProps }: Props = $props();
</script>

<svelte:element
	this={href ? 'a' : 'div'}
	{href}
	class={cn('flex items-center gap-2', className)}
	{...restProps}
>
	<BrandLogo />
	<BrandWordmark />
</svelte:element>
