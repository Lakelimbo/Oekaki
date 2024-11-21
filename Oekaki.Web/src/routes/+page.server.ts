import { client } from '$lib/data/client';

export const load = async () => {
	const { data, error } = await client.GET('/WeatherForecast');

	return {
		response: data,
		error: error
	};
};
