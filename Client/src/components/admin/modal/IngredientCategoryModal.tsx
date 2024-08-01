import { Modal } from 'rsuite';
import IngredientCategoryListing from '../listing/IngredientCategoryListing';

interface IIngredientCategoryModal {
    open: boolean;
    closeModal: () => void;
}

const IngredientCategoryModal = ({ open, closeModal }: IIngredientCategoryModal) => {
    return (
        <Modal className='modal' size={'lg'} open={open} onClose={() => closeModal()}>
            <Modal.Header>
                <Modal.Title>Ingredient Categories</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <IngredientCategoryListing />
            </Modal.Body>
            <Modal.Footer></Modal.Footer>
        </Modal>
    );
};

export default IngredientCategoryModal;
