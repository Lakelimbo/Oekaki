// @ts-nocheck
import { error, fail, redirect, type Actions } from '@sveltejs/kit';
import { superValidate } from 'sveltekit-superforms';
import { zod } from 'sveltekit-superforms/adapters';
import { registerSchema } from '../schema';
import type { PageServerLoad } from './$types';
import { client } from '$lib/data/client';

export const load = async () => {
	return {
		form: await superValidate(zod(registerSchema))
	};
};

export const actions = {
	default: async (event: import('./$types').RequestEvent) => {
		const form = await superValidate(event, zod(registerSchema));
		if (!form.valid) {
			return fail(400, {
				data: form,
				errors: form.errors
			});
		}

		const request = await client.POST('/register', {
			body: {
				email: form.data.email,
				password: form.data.password,
				username: form.data.username
			},
			fetch: event.fetch,
			credentials: 'include'
		});

		if (!request.response.ok) {
			error(request.response.status, {
				message: request.error?.errors?.['DuplicateUsername']
					? `Email '${form.data.email} is already taken.'`
					: 'An unknown error happened. Please try again'
			});
		}

		redirect(303, '/login');
	}
};
;null as any as PageServerLoad;;null as any as Actions;