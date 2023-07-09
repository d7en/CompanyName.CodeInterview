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
        <div className="row">
            <div className="col-sm-6">
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Full name</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map(user =>
                            <UserListItem user={user} key={user.id} />
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    )
}
