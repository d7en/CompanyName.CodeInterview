import { UserListItem } from './UserListItem.tsx';
import { User } from './users-api-client';

type UserListProps = { users: User[] };
export const UserList = (props: UserListProps) => {
    const { users } = props;

    if (users.length == 0) {
        return (
            <p>No users were found</p>
        );
    }

    return (
        <div>
            <ul>
                There are {users.length} users
                {users.map(user => 
                    <UserListItem user={user} key={user.id} />
                )}
            </ul>
        </div>
    )
}
