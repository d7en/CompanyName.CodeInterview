# Getting started
If you have just cloned this project, install all necessary dependencies:

### `npm install`

Then, the frontend can be started with the following command:

### `npm run dev`

And voilá, the frontend should now be up and running.

# Context
If you open `App.tsx`, you'll see that some hardcoded, mocked data is currently present, in the variable called `mockedUsers`.

There are already two components created, namely `UserList.tsx` and `UserListItem.tsx`. These
are present only as guidance, feel free to use them or discard them.

In the `.env` file, the environment variables are already configured according to the values defined
in the backend. Please use these in your coding challenge. The frontend part was created using `Vite`,
if you're unfamiliar with environment variable in `Vite`, they are accessed with the following syntax:
- `import.meta.env.VITE_BACKEND_URL`
- `import.meta.env.VITE_USERS_ENDPOINT_URL`
- `import.meta.env.VITE_TASKS_ENDPOINT_URL`

# Tasks
1) Delete the variable `mockedData` and instead fetch data from the backend. The data model present in the
backend is the same, though the content might be different.
2) While the request for data is being processed by the backend, display any sort of loader to 
show that data is currently being fetched
3) When data is finally fetched, display it as a list. There are already two components created for that
purpose, `UserList.tsx` and `UserListItem.tsx`. Feel free to use them as is, or discard/create your own.
4) Implement two filters, one for name, and one for email. There are already two inputs present in the
`UserList.tsx` component. Feel free to use them as is, or discard/create your own.
   1) The list being displayed should be filtered based on the values present in both inputs.
   E.g. if `gmail` is typed in the email field and `ader` is typed in the name field, only users whose
   email includes the string `gmail` AND whose name or surname includes `ader` should appear.

# Bonus tasks
1) Show a stopwatch on the page that starts running when the fetch request is fired and stops
running when the data is received. It should have the format `mm:ss:ms` where:
   - `mm` represents minutes
   - `ss` represents seconds
   - `mls` represents milliseconds
   - e.g. `00:03:813` (this would mean the request took 3 second and 813 milliseconds)
2) Any kind of styling is highly appreciated
