import { useState } from 'react';
import { useData } from '../../../hooks/useData';
import { Modal, Button } from 'rsuite';
import { IData } from '../../../types/IData';
import ImageButton from '../../common/input/ImageButton';
import { nanoid } from 'nanoid';

interface IImageSelectorModal {
    open: boolean;
    api: string;
    closeModal: () => void;
    selectImage: (src: string) => void;
}

const ImageSelectorModal = ({ open, api, closeModal, selectImage }: IImageSelectorModal) => {
    const [selected, setSelected] = useState<number>();
    const [selectedSrc, setSelectedSrc] = useState('');
    const { data, refresh } = useData('image/listing');

    const clickImage = (src: string, index: number) => {
        setSelectedSrc(src);
        setSelected(index);
    };
    return (
        <Modal
            className='modal'
            size={'lg'}
            open={open}
            onOpen={() => {
                refresh();
            }}
            onClose={() => closeModal()}
        >
            <Modal.Header>
                <Modal.Title>Select an image</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className='image-selector-collection'>
                    {data.map((img: IData, index: number) => {
                        const imgName = img as unknown as string;
                        const trueSrc = `${api}/${imgName}`;
                        return (
                            <span className={`image-selection${index === selected ? ' active' : ''}`} key={nanoid()}>
                                <ImageButton
                                    className='image-selection-image'
                                    src={trueSrc}
                                    onClick={() => {
                                        clickImage(imgName, index);
                                    }}
                                />
                            </span>
                        );
                    })}
                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button onClick={() => selectImage(selectedSrc)} appearance='primary'>
                    Select
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default ImageSelectorModal;
