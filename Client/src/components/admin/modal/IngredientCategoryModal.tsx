import { Modal } from 'rsuite';
import IngredientCategoryListing from '../listing/IngredientCategoryListing';
import ModalHeader from '../../common/header/ModalHeader';

interface IIngredientCategoryModal {
    open: boolean;
    closeModal: () => void;
    refresher: () => void;
}

const IngredientCategoryModal = ({ open, closeModal, refresher }: IIngredientCategoryModal) => {
    return (
        <Modal className='modal' size={'lg'} open={open} onClose={() => closeModal()}>
            <ModalHeader title='Ingredient Categories' />
            <Modal.Body>
                <IngredientCategoryListing refresher={refresher} />
            </Modal.Body>
            <Modal.Footer></Modal.Footer>
        </Modal>
    );
};

export default IngredientCategoryModal;
