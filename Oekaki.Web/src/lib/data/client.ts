import createClient from 'openapi-fetch';
import type { paths } from './openapi-schema-v1';

/**
 * Workaround for the proxied URI on development
 */
const proxiedUrl = `http://localhost:${process.env.PORT}/api`;

export const client = createClient<paths>({
	baseUrl: proxiedUrl
});
