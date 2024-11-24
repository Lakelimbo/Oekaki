import { client } from '$lib/data/client';

export const load = async ({ fetch }) => {
	const { data, error } = await client.GET('/Tests/{id}', {
		params: {
			path: {
				id: 1
			}
		},
		fetch
	});

	// const { data, error } = await client.GET('/manage/info', {
	// 	fetch,
	// 	credentials: 'include'
	// });

	return {
		response: data,
		error: error
	};
};
