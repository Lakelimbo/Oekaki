<script lang="ts">
	import { browser } from '$app/environment';
	import * as Card from '$lib/components/ui/card';
	import * as Form from '$lib/components/ui/form';
	import { Input } from '$lib/components/ui/input';
	import { toast } from 'svelte-sonner';
	import SuperDebug, { superForm, type Infer, type SuperValidated } from 'sveltekit-superforms';
	import { zodClient } from 'sveltekit-superforms/adapters';
	import { registerSchema, type RegisterSchema } from '../schema';

	let { form: data }: { form: SuperValidated<Infer<RegisterSchema>> } = $props();

	let isLoading: boolean = $state(false);
	const form = superForm(data, {
		dataType: 'json',
		validators: zodClient(registerSchema),
		onUpdated: ({ form: f }) => {
			if (!f.valid) {
				toast.error('Fix the errors to create your account');
			}
		},
		onResult: ({ result }) => {
			if (result.type === 'success') {
				toast.success('Successfully registered!');
			}
		},
		onError: ({ result }) => {
			toast.error(result.error.message);
		}
	});

	const { form: formData, enhance } = form;
</script>

<Card.Root>
	<Card.Header>
		<Card.Title>Creating a new account</Card.Title>
	</Card.Header>
	<Card.Content>
		<form method="POST" use:enhance>
			<Form.Field {form} name="username">
				<Form.Control>
					{#snippet children({ props })}
						<Form.Label>Username</Form.Label>
						<Input {...props} bind:value={$formData.username} placeholder="James Bond" />
						<Form.FieldErrors />
					{/snippet}
				</Form.Control>
			</Form.Field>
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
			<Form.Field {form} name="passwordConfirm" class="mt-2">
				<Form.Control>
					{#snippet children({ props })}
						<Form.Label>Confirm password</Form.Label>
						<Input {...props} bind:value={$formData.passwordConfirm} type="password" />
						<Form.FieldErrors />
					{/snippet}
				</Form.Control>
			</Form.Field>
			<p class="my-4 text-center text-sm font-medium text-muted-foreground">
				By creating an account you agree with our <a href="/tos" class="link">Terms of Service</a>
				and
				<a href="/privacy" class="link">Privacy Policy</a>
			</p>
			<Form.Button disabled={isLoading} class="w-full">Create account</Form.Button>
		</form>
	</Card.Content>
</Card.Root>
{#if browser}
	<div class="mt-4">
		<SuperDebug data={$formData} />
	</div>
{/if}
