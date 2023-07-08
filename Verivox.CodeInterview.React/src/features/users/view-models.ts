export interface UserFilterViewModel {
    email: string;
    name: string;
}

export interface UsersLoadingState {
    loading: boolean;
    error?: any;
}