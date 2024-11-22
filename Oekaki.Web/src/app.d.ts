// See https://svelte.dev/docs/kit/types#app.d.ts

import type { components } from '$lib/data/openapi-schema-v1';

// for information about these interfaces
declare global {
	namespace App {
		// interface Error {}
		interface Locals {
			user?: components['schemas']['InfoResponse'];
		}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
}

export {};
