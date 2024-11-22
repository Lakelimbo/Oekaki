
// this file is generated — do not edit it


/// <reference types="@sveltejs/kit" />

/**
 * Environment variables [loaded by Vite](https://vitejs.dev/guide/env-and-mode.html#env-files) from `.env` files and `process.env`. Like [`$env/dynamic/private`](https://svelte.dev/docs/kit/$env-dynamic-private), this module cannot be imported into client-side code. This module only includes variables that _do not_ begin with [`config.kit.env.publicPrefix`](https://svelte.dev/docs/kit/configuration#env) _and do_ start with [`config.kit.env.privatePrefix`](https://svelte.dev/docs/kit/configuration#env) (if configured).
 * 
 * _Unlike_ [`$env/dynamic/private`](https://svelte.dev/docs/kit/$env-dynamic-private), the values exported from this module are statically injected into your bundle at build time, enabling optimisations like dead code elimination.
 * 
 * ```ts
 * import { API_KEY } from '$env/static/private';
 * ```
 * 
 * Note that all environment variables referenced in your code should be declared (for example in an `.env` file), even if they don't have a value until the app is deployed:
 * 
 * ```
 * MY_FEATURE_FLAG=""
 * ```
 * 
 * You can override `.env` values from the command line like so:
 * 
 * ```bash
 * MY_FEATURE_FLAG="enabled" npm run dev
 * ```
 */
declare module '$env/static/private' {
	export const SHELL: string;
	export const npm_command: string;
	export const SESSION_MANAGER: string;
	export const OTEL_BSP_SCHEDULE_DELAY: string;
	export const DOTNET_ROOT_X64: string;
	export const USER_ZDOTDIR: string;
	export const npm_config_userconfig: string;
	export const COLORTERM: string;
	export const OTEL_EXPORTER_OTLP_PROTOCOL: string;
	export const npm_config_cache: string;
	export const XDG_MENU_PREFIX: string;
	export const TERM_PROGRAM_VERSION: string;
	export const NODE: string;
	export const OTEL_EXPORTER_OTLP_HEADERS: string;
	export const LC_ADDRESS: string;
	export const LC_NAME: string;
	export const MEMORY_PRESSURE_WRITE: string;
	export const COLOR: string;
	export const npm_config_local_prefix: string;
	export const DESKTOP_SESSION: string;
	export const LC_MONETARY: string;
	export const NO_AT_BRIDGE: string;
	export const MSBuildLoadMicrosoftTargetsReadOnly: string;
	export const npm_config_globalconfig: string;
	export const EDITOR: string;
	export const ConnectionStrings__oekakidb: string;
	export const PWD: string;
	export const OTEL_RESOURCE_ATTRIBUTES: string;
	export const XDG_SESSION_DESKTOP: string;
	export const LOGNAME: string;
	export const XDG_SESSION_TYPE: string;
	export const PORT: string;
	export const npm_config_init_module: string;
	export const SYSTEMD_EXEC_PID: string;
	export const NODE_ENV: string;
	export const _: string;
	export const XAUTHORITY: string;
	export const VSCODE_GIT_ASKPASS_NODE: string;
	export const GJS_DEBUG_TOPICS: string;
	export const MOTD_SHOWN: string;
	export const VSCODE_INJECTION: string;
	export const GDM_LANG: string;
	export const HOME: string;
	export const USERNAME: string;
	export const OTEL_EXPORTER_OTLP_ENDPOINT: string;
	export const LANG: string;
	export const LC_PAPER: string;
	export const services__coreapi__http__0: string;
	export const XDG_CURRENT_DESKTOP: string;
	export const npm_package_version: string;
	export const MEMORY_PRESSURE_WATCH: string;
	export const STARSHIP_SHELL: string;
	export const WAYLAND_DISPLAY: string;
	export const DOTNET_DASHBOARD_OTLP_ENDPOINT_URL: string;
	export const GIT_ASKPASS: string;
	export const INVOCATION_ID: string;
	export const MANAGERPID: string;
	export const INIT_CWD: string;
	export const CHROME_DESKTOP: string;
	export const STARSHIP_SESSION_KEY: string;
	export const npm_lifecycle_script: string;
	export const GJS_DEBUG_OUTPUT: string;
	export const GNOME_SETUP_DISPLAY: string;
	export const npm_config_npm_version: string;
	export const XDG_SESSION_CLASS: string;
	export const TERM: string;
	export const LC_IDENTIFICATION: string;
	export const npm_package_name: string;
	export const npm_config_prefix: string;
	export const ZDOTDIR: string;
	export const OTEL_TRACES_SAMPLER: string;
	export const services__coreapi__https__0: string;
	export const USER: string;
	export const VSCODE_GIT_IPC_HANDLE: string;
	export const VISUAL: string;
	export const OTEL_METRICS_EXEMPLAR_FILTER: string;
	export const DISPLAY: string;
	export const npm_lifecycle_event: string;
	export const SHLVL: string;
	export const LC_TELEPHONE: string;
	export const LC_MEASUREMENT: string;
	export const npm_config_user_agent: string;
	export const npm_execpath: string;
	export const XDG_RUNTIME_DIR: string;
	export const DEBUGINFOD_URLS: string;
	export const LC_TIME: string;
	export const npm_package_json: string;
	export const VSCODE_GIT_ASKPASS_MAIN: string;
	export const JOURNAL_STREAM: string;
	export const XDG_DATA_DIRS: string;
	export const DOTNET_RESOURCE_SERVICE_ENDPOINT_URL: string;
	export const GDK_BACKEND: string;
	export const OTEL_SERVICE_NAME: string;
	export const OTEL_METRIC_EXPORT_INTERVAL: string;
	export const OTEL_BLRP_SCHEDULE_DELAY: string;
	export const BROWSER: string;
	export const npm_config_noproxy: string;
	export const PATH: string;
	export const npm_config_node_gyp: string;
	export const GDMSESSION: string;
	export const ORIGINAL_XDG_CURRENT_DESKTOP: string;
	export const DBUS_SESSION_BUS_ADDRESS: string;
	export const npm_config_global_prefix: string;
	export const MAIL: string;
	export const GIO_LAUNCHED_DESKTOP_FILE_PID: string;
	export const npm_node_execpath: string;
	export const npm_config_engine_strict: string;
	export const GIO_LAUNCHED_DESKTOP_FILE: string;
	export const LC_NUMERIC: string;
	export const OLDPWD: string;
	export const TERM_PROGRAM: string;
}

/**
 * Similar to [`$env/static/private`](https://svelte.dev/docs/kit/$env-static-private), except that it only includes environment variables that begin with [`config.kit.env.publicPrefix`](https://svelte.dev/docs/kit/configuration#env) (which defaults to `PUBLIC_`), and can therefore safely be exposed to client-side code.
 * 
 * Values are replaced statically at build time.
 * 
 * ```ts
 * import { PUBLIC_BASE_URL } from '$env/static/public';
 * ```
 */
declare module '$env/static/public' {
	
}

/**
 * This module provides access to runtime environment variables, as defined by the platform you're running on. For example if you're using [`adapter-node`](https://github.com/sveltejs/kit/tree/main/packages/adapter-node) (or running [`vite preview`](https://svelte.dev/docs/kit/cli)), this is equivalent to `process.env`. This module only includes variables that _do not_ begin with [`config.kit.env.publicPrefix`](https://svelte.dev/docs/kit/configuration#env) _and do_ start with [`config.kit.env.privatePrefix`](https://svelte.dev/docs/kit/configuration#env) (if configured).
 * 
 * This module cannot be imported into client-side code.
 * 
 * Dynamic environment variables cannot be used during prerendering.
 * 
 * ```ts
 * import { env } from '$env/dynamic/private';
 * console.log(env.DEPLOYMENT_SPECIFIC_VARIABLE);
 * ```
 * 
 * > In `dev`, `$env/dynamic` always includes environment variables from `.env`. In `prod`, this behavior will depend on your adapter.
 */
declare module '$env/dynamic/private' {
	export const env: {
		SHELL: string;
		npm_command: string;
		SESSION_MANAGER: string;
		OTEL_BSP_SCHEDULE_DELAY: string;
		DOTNET_ROOT_X64: string;
		USER_ZDOTDIR: string;
		npm_config_userconfig: string;
		COLORTERM: string;
		OTEL_EXPORTER_OTLP_PROTOCOL: string;
		npm_config_cache: string;
		XDG_MENU_PREFIX: string;
		TERM_PROGRAM_VERSION: string;
		NODE: string;
		OTEL_EXPORTER_OTLP_HEADERS: string;
		LC_ADDRESS: string;
		LC_NAME: string;
		MEMORY_PRESSURE_WRITE: string;
		COLOR: string;
		npm_config_local_prefix: string;
		DESKTOP_SESSION: string;
		LC_MONETARY: string;
		NO_AT_BRIDGE: string;
		MSBuildLoadMicrosoftTargetsReadOnly: string;
		npm_config_globalconfig: string;
		EDITOR: string;
		ConnectionStrings__oekakidb: string;
		PWD: string;
		OTEL_RESOURCE_ATTRIBUTES: string;
		XDG_SESSION_DESKTOP: string;
		LOGNAME: string;
		XDG_SESSION_TYPE: string;
		PORT: string;
		npm_config_init_module: string;
		SYSTEMD_EXEC_PID: string;
		NODE_ENV: string;
		_: string;
		XAUTHORITY: string;
		VSCODE_GIT_ASKPASS_NODE: string;
		GJS_DEBUG_TOPICS: string;
		MOTD_SHOWN: string;
		VSCODE_INJECTION: string;
		GDM_LANG: string;
		HOME: string;
		USERNAME: string;
		OTEL_EXPORTER_OTLP_ENDPOINT: string;
		LANG: string;
		LC_PAPER: string;
		services__coreapi__http__0: string;
		XDG_CURRENT_DESKTOP: string;
		npm_package_version: string;
		MEMORY_PRESSURE_WATCH: string;
		STARSHIP_SHELL: string;
		WAYLAND_DISPLAY: string;
		DOTNET_DASHBOARD_OTLP_ENDPOINT_URL: string;
		GIT_ASKPASS: string;
		INVOCATION_ID: string;
		MANAGERPID: string;
		INIT_CWD: string;
		CHROME_DESKTOP: string;
		STARSHIP_SESSION_KEY: string;
		npm_lifecycle_script: string;
		GJS_DEBUG_OUTPUT: string;
		GNOME_SETUP_DISPLAY: string;
		npm_config_npm_version: string;
		XDG_SESSION_CLASS: string;
		TERM: string;
		LC_IDENTIFICATION: string;
		npm_package_name: string;
		npm_config_prefix: string;
		ZDOTDIR: string;
		OTEL_TRACES_SAMPLER: string;
		services__coreapi__https__0: string;
		USER: string;
		VSCODE_GIT_IPC_HANDLE: string;
		VISUAL: string;
		OTEL_METRICS_EXEMPLAR_FILTER: string;
		DISPLAY: string;
		npm_lifecycle_event: string;
		SHLVL: string;
		LC_TELEPHONE: string;
		LC_MEASUREMENT: string;
		npm_config_user_agent: string;
		npm_execpath: string;
		XDG_RUNTIME_DIR: string;
		DEBUGINFOD_URLS: string;
		LC_TIME: string;
		npm_package_json: string;
		VSCODE_GIT_ASKPASS_MAIN: string;
		JOURNAL_STREAM: string;
		XDG_DATA_DIRS: string;
		DOTNET_RESOURCE_SERVICE_ENDPOINT_URL: string;
		GDK_BACKEND: string;
		OTEL_SERVICE_NAME: string;
		OTEL_METRIC_EXPORT_INTERVAL: string;
		OTEL_BLRP_SCHEDULE_DELAY: string;
		BROWSER: string;
		npm_config_noproxy: string;
		PATH: string;
		npm_config_node_gyp: string;
		GDMSESSION: string;
		ORIGINAL_XDG_CURRENT_DESKTOP: string;
		DBUS_SESSION_BUS_ADDRESS: string;
		npm_config_global_prefix: string;
		MAIL: string;
		GIO_LAUNCHED_DESKTOP_FILE_PID: string;
		npm_node_execpath: string;
		npm_config_engine_strict: string;
		GIO_LAUNCHED_DESKTOP_FILE: string;
		LC_NUMERIC: string;
		OLDPWD: string;
		TERM_PROGRAM: string;
		[key: `PUBLIC_${string}`]: undefined;
		[key: `${string}`]: string | undefined;
	}
}

/**
 * Similar to [`$env/dynamic/private`](https://svelte.dev/docs/kit/$env-dynamic-private), but only includes variables that begin with [`config.kit.env.publicPrefix`](https://svelte.dev/docs/kit/configuration#env) (which defaults to `PUBLIC_`), and can therefore safely be exposed to client-side code.
 * 
 * Note that public dynamic environment variables must all be sent from the server to the client, causing larger network requests — when possible, use `$env/static/public` instead.
 * 
 * Dynamic environment variables cannot be used during prerendering.
 * 
 * ```ts
 * import { env } from '$env/dynamic/public';
 * console.log(env.PUBLIC_DEPLOYMENT_SPECIFIC_VARIABLE);
 * ```
 */
declare module '$env/dynamic/public' {
	export const env: {
		[key: `PUBLIC_${string}`]: string | undefined;
	}
}
