import { User } from "./api/users-api-client";

type UserListItemProps = { user: User };
export const UserListItem = (props: UserListItemProps) => {
    const { user } = props;
    const { id, email, name, surname } = user;

    return (
        <li>
            {id} - {name} {surname} ({email})
        </li>
    )
}
