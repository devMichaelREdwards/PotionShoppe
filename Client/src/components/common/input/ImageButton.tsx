import { Button } from 'rsuite';

interface IImageButton {
    src: string;
    className?: string;
    loading?: boolean;
    onClick: () => Promise<void>;
}

const ImageButton = ({ src, className, loading, onClick }: IImageButton) => {
    return (
        <Button appearance='primary' onClick={onClick} loading={loading}>
            <div className={`image-button ${className}`}>
                <img src={src} />
                {!loading && <div className='image-button-text'>Sign In</div>}
            </div>
        </Button>
    );
};

export default ImageButton;
