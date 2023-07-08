import { UserFilterViewModel } from "./view-models";

type UserFilterProps = {
    userFilter: UserFilterViewModel,
    setUserFilterCallback: (model: UserFilterViewModel) => void;
};
export const UserFilter = (props: UserFilterProps) => {
    const { userFilter, setUserFilterCallback } = props;

    return (
        <form>
            <fieldset>
                <legend>Filter</legend>

                <div>
                    <label htmlFor={'email'}>Email</label>
                    <input type={'email'} id={'email'} value={userFilter.email} onChange={e => setUserFilterCallback({ ...userFilter, email: e.target.value || '' })} />
                </div>

                <div>
                    <label htmlFor={'name'}>Name</label>
                    <input type={'text'} id={'name'} value={userFilter.name} onChange={e => setUserFilterCallback({ ...userFilter, name: e.target.value || '' })} />
                </div>
            </fieldset>
        </form>
    )
}
