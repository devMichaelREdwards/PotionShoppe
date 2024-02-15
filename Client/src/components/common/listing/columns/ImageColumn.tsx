interface IProps {
    src: string;
}
const ImageColumn = ({ src }: IProps) => {
    return <img src={src} />;
};

export default ImageColumn;
