import { User } from "./api/users-api-client";

type UserListItemProps = { user: User };
export const UserListItem = (props: UserListItemProps) => {
    const { user } = props;
    const { id, email, name, surname } = user;

    return (
        <tr>
            <td>{id}</td>
            <td>{name} {surname}</td>
            <td>{email}</td>
        </tr>
    )
}
