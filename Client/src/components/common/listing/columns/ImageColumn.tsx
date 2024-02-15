interface IProps {
    src: string;
}
const ImageColumn = ({ src }: IProps) => {
    return <img className='img-column' src={src} />;
};

export default ImageColumn;
