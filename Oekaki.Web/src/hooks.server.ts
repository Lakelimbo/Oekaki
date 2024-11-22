import { client } from '$lib/data/client';
import type { Handle } from '@sveltejs/kit';
import { sequence } from '@sveltejs/kit/hooks';

export const validateAuth: Handle = async ({ event, resolve }) => {
	const request = await client.GET('/manage/info', {
		fetch: event.fetch,
		credentials: 'include'
	});

	if (request.response.ok) {
		event.locals.user = request.data;
	}

	return await resolve(event);
};

export const serializeResponses: Handle = async ({ event, resolve }) => {
	return resolve(event, {
		filterSerializedResponseHeaders(name) {
			return name === 'content-length';
		}
	});
};

export const handle: Handle = sequence(serializeResponses, validateAuth);
