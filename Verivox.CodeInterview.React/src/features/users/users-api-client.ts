export class UsersApiClient {
    async getAllUsersList(): Promise<User[]> {
        const usersResponse = await fetch(`${import.meta.env.VITE_BACKEND_URL}/${import.meta.env.VITE_USERS_ENDPOINT_URL}`);
        const usersResponseJson = await usersResponse.json();
        console.log(usersResponseJson);
        return usersResponseJson;
    }
}


export type User = {
    id: number;
    email: string;
    name: string;
    surname: string;
}