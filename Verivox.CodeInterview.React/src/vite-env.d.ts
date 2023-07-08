/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_BACKEND_URL: string;
    readonly VITE_USERS_ENDPOINT_URL: string;
    readonly VITE_TASKS_ENDPOINT_URL: string;
}

interface ImportMeta {
    readonly env: ImportMetaEnv;
}
