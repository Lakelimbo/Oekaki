import type { CookieSameSite } from '$lib/data/arbitrary-types';
import { client } from '$lib/data/client';
import { error, fail, redirect, type Actions } from '@sveltejs/kit';
import { parseString } from 'set-cookie-parser';
import { superValidate } from 'sveltekit-superforms';
import { zod } from 'sveltekit-superforms/adapters';
import { loginSchema } from '../schema';
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({ locals }) => {
	if (locals.user) {
		redirect(302, '/');
	}

	return {
		form: await superValidate(zod(loginSchema))
	};
};

export const actions: Actions = {
	default: async (event) => {
		const form = await superValidate(event, zod(loginSchema));
		if (!form.valid) {
			return fail(400, {
				data: form,
				errors: form.errors
			});
		}

		const request = await client.POST('/Users/login', {
			body: {
				email: form.data.email,
				password: form.data.password
			},
			params: {
				query: {
					useCookies: true
				}
			},
			fetch: event.fetch,
			credentials: 'include'
		});

		if (!request.response.ok) {
			error(request.response.status, {
				message:
					request.response.status === 401
						? 'Incorrect email or password'
						: 'An unknown error happened. Please try again'
			});
		}

		const cookie = parseString(request.response.headers.get('set-cookie')!);
		event.cookies.set(cookie.name, cookie.value, {
			expires: cookie.expires,
			path: cookie.path || '/',
			secure: cookie.secure,
			sameSite: (cookie.sameSite as CookieSameSite) || 'lax',
			httpOnly: cookie.httpOnly
		});

		redirect(303, '/');
	}
};
