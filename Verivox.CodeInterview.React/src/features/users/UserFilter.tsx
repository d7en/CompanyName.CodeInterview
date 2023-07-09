import { UserFilterViewModel } from "./view-models";

type UserFilterProps = {
    userFilter: UserFilterViewModel,
    setUserFilterCallback: (model: UserFilterViewModel) => void;
};
export const UserFilter = (props: UserFilterProps) => {
    const { userFilter, setUserFilterCallback } = props;

    return (
        <form className="mb-3">
            <div className="row">
                <div className="col-sm-12">
                    <h5>Filters:</h5>
                </div>
                <div className="col-sm-12 col-md-3">
                    <input placeholder="email" className="form-control" type={'email'} id={'email'} value={userFilter.email} onChange={e => setUserFilterCallback({ ...userFilter, email: e.target.value || '' })} />
                </div>

                <div className="col-sm-12 col-md-3">
                    <input placeholder="name" className="form-control" type={'text'} id={'name'} value={userFilter.name} onChange={e => setUserFilterCallback({ ...userFilter, name: e.target.value || '' })} />
                </div>
            </div>
        </form>
    )
}
