import { error, fail, redirect, type Actions } from '@sveltejs/kit';
import { superValidate } from 'sveltekit-superforms';
import { zod } from 'sveltekit-superforms/adapters';
import { registerSchema } from '../schema';
import type { PageServerLoad } from './$types';
import { client } from '$lib/data/client';

export const load: PageServerLoad = async () => {
	return {
		form: await superValidate(zod(registerSchema))
	};
};

export const actions: Actions = {
	default: async (event) => {
		const form = await superValidate(event, zod(registerSchema));
		if (!form.valid) {
			return fail(400, {
				data: form,
				errors: form.errors
			});
		}

		const request = await client.POST('/Users/signup', {
			body: {
				// userName which is actually the email... Ikr
				userName: form.data.email,
				email: form.data.email,
				password: form.data.password,
				passwordConfirm: form.data.passwordConfirm,
				nickname: form.data.username
			},
			fetch: event.fetch,
			credentials: 'include'
		});

		if (!request.response.ok) {
			error(request.response.status, {
				message: 'An error happened. Please try again.'
			});
		}

		redirect(303, '/login');
	}
};
