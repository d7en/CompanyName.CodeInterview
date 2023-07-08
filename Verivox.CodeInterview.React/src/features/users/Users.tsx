import { UserList } from './UserList.tsx';
import { UserFilter } from './UserFilter.tsx';
import { useEffect, useMemo, useState } from 'react';
import { UserFilterViewModel, UsersLoadingState } from './view-models';
import { User, UsersApiClient } from './users-api-client';
import { Loading } from '../../shared/components/Loading.tsx';
import { useStopWatch } from '../../hooks/useStopWatch';

export const Users = () => {

    // DI?
    const usersApiClient = new UsersApiClient();

    /* states */
    const defaultUsersState: User[] = [];
    const [users, setUsers] = useState(defaultUsersState);

    const defaultUserFilter: UserFilterViewModel = { name: '', email: '' };
    const [userFilter, setUserFilter] = useState(defaultUserFilter);

    const defaultUsersLoadingState: UsersLoadingState = { loading: false, error: null };
    const [usersLoadingState, setUsersLoadingState] = useState(defaultUsersLoadingState);
    const [searchUsersWithStopWatch, stopWatchValue] = useStopWatch(async () => {
        await searchUsers();
    });

    /* functions */
    const searchUsers = async () => {
        setUsersLoadingState({ ...usersLoadingState, loading: true, error: null });
        try {
            const usersResponse = await usersApiClient.getAllUsersList();
            setUsers(usersResponse);
            setUsersLoadingState({ ...usersLoadingState, loading: false, error: null });
        }
        catch (e) {
            console.log(e);
            setUsersLoadingState({ ...usersLoadingState, loading: false, error: e });
        }
    };

    /* init effect */
    useEffect(() => {
        searchUsersWithStopWatch();
    }, []);

    /* search users effect */
    const filteredUsers = useMemo(() => {
        if (!userFilter.email && !userFilter.name) return users;

        const lowerCaseUserFilter = {
            email: (userFilter.email || '').trim().toLowerCase(),
            name: (userFilter.name || '').trim().toLowerCase()
        };
        const filteredUsers = [...users].filter(x =>
            (x.name + x.surname).toLowerCase().includes(lowerCaseUserFilter.name) &&
            x.email.toLowerCase().includes(lowerCaseUserFilter.email)
        );

        return filteredUsers;
    }, [userFilter.name, userFilter.email, users]);

    return (
        <div>
            {
                usersLoadingState.loading
                    ? <Loading text='Loading users...' />
                    : usersLoadingState.error
                        ? <div>The next error occured while loading users: {String(usersLoadingState.error)}</div>
                        :
                        <div>
                            <UserFilter userFilter={userFilter} setUserFilterCallback={setUserFilter} />
                            <UserList users={filteredUsers} />
                        </div>

            }
            {
                stopWatchValue && <div>Users get request took: {stopWatchValue}</div>
            }
        </div>
    )
}
