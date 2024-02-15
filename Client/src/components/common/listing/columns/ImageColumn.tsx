interface IProps {
    src: string;
}
const ImageColumn = ({ src }: IProps) => {
    return (
        <div className='img-column'>
            <img src={src} />
        </div>
    );
};

export default ImageColumn;
