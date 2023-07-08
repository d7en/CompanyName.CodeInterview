type LoadingProps = {
    text?: string;
};
export const Loading = (props: LoadingProps) => {
    const { text } = props;

    return (
        <p>{text ?? 'Loading...'}</p>
    )
}
