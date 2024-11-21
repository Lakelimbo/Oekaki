import { defineConfig } from 'vitest/config';
import { sveltekit } from '@sveltejs/kit/vite';

export default defineConfig({
	plugins: [sveltekit()],
	server: {
		host: true,
		port: parseInt(process.env.PORT ?? '5173'),
		proxy: {
			'/api': {
				target: process.env.services__coreapi__https__0 || process.env.services__coreapi__http__0,
				changeOrigin: true,
				rewrite: (path) => path.replace(/^\/api/, ''),
				secure: false
			}
		}
	},
	test: {
		include: ['src/**/*.{test,spec}.{js,ts}']
	}
});
