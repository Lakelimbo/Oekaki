import { redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({ locals, fetch }) => {
	if (!locals.user) {
		redirect(401, '/');
	}

	/**
	 * Not sure why but the client simply does not
	 * allow to log out? It's like as if it does not
	 * send (or receives) the request/response
	 * appropriately.
	 *
	 * Using a regular fetch() for the time being.
	 */

	// await client.POST('/Users/logout', {
	// 	body: '{}',
	// 	headers: {
	// 		accept: '*/*',
	// 		'Content-Type': 'application/json'
	// 	},
	// 	credentials: 'include',
	// 	fetch
	// });

	await fetch('/api/Users/logout', {
		method: 'POST',
		headers: {
			accept: '*/*',
			'Content-Type': 'application/json'
		},
		body: '{}'
	});

	redirect(303, '/');
};
