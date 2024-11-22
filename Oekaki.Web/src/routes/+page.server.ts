import { client } from '$lib/data/client';

export const load = async () => {
	const { data, error } = await client.GET('/api/Tests/{id}', {
		params: {
			path: {
				id: 1
			}
		}
	});

	return {
		response: data,
		error: error
	};
};
