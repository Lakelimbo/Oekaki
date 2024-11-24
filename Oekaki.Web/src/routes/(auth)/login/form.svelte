<script lang="ts">
	import { browser } from '$app/environment';
	import * as Card from '$lib/components/ui/card';
	import * as Form from '$lib/components/ui/form';
	import { Input } from '$lib/components/ui/input';
	import { toast } from 'svelte-sonner';
	import SuperDebug, { superForm, type Infer, type SuperValidated } from 'sveltekit-superforms';
	import { zodClient } from 'sveltekit-superforms/adapters';
	import { loginSchema, type LoginSchema } from '../schema';

	let { form: data }: { form: SuperValidated<Infer<LoginSchema>> } = $props();

	let isLoading: boolean = $state(false);
	const form = superForm(data, {
		dataType: 'json',
		validators: zodClient(loginSchema),
		onUpdated: ({ form: f }) => {
			if (!f.valid) {
				toast.error('Fix the errors to log in to your account');
			}
		},
		onResult: ({ result }) => {
			switch (result.status) {
				case 303:
					toast.success('Successfully logged in!');
					break;
				case 401:
					toast.error('Incorrect email or password');
					break;
				case 400:
					break;
				default:
					toast.error('An unknown error happened. Please try again.');
			}
		}
	});

	const { form: formData, enhance } = form;
</script>

<Card.Root>
	<Card.Header>
		<Card.Title>Log in to your account</Card.Title>
	</Card.Header>
	<Card.Content>
		<form method="POST" use:enhance>
			<Form.Field {form} name="email" class="mt-2">
				<Form.Control>
					{#snippet children({ props })}
						<Form.Label>Email</Form.Label>
						<Input
							{...props}
							bind:value={$formData.email}
							type="email"
							placeholder="golden@eye.com"
						/>
						<Form.FieldErrors />
					{/snippet}
				</Form.Control>
			</Form.Field>
			<Form.Field {form} name="password" class="mt-2">
				<Form.Control>
					{#snippet children({ props })}
						<Form.Label>Password</Form.Label>
						<Input {...props} bind:value={$formData.password} type="password" />
						<Form.FieldErrors />
					{/snippet}
				</Form.Control>
			</Form.Field>
			<Form.Button disabled={isLoading} class="mt-4 w-full">Log in</Form.Button>
		</form>
	</Card.Content>
</Card.Root>
{#if browser}
	<div class="mt-4">
		<SuperDebug data={$formData} />
	</div>
{/if}
