import { Button } from 'rsuite';

interface IImageButton {
    src: string;
    className?: string;
    loading?: boolean;
    label?: string;
    onClick: () => Promise<void> | void;
}

const ImageButton = ({ src, className, loading, label, onClick }: IImageButton) => {
    return (
        <Button appearance='primary' className='image-button-wrapper' onClick={onClick} loading={loading}>
            <div className={`image-button ${className}`}>
                <img src={src} />
                {!loading && label && <div className='image-button-text'>{label}</div>}
            </div>
        </Button>
    );
};

export default ImageButton;
