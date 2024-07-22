import { Modal } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import ActionButtonCollection from '../../common/input/ActionButtonCollection';

interface IConfirmationModal {
    open: boolean;
    closeModal: () => void;
    confirmationCallback?: () => void;
}

const ConfirmationModal = ({ open, confirmationCallback, closeModal }: IConfirmationModal) => {
    const confirm = (confirm: boolean) => {
        if (confirm) confirmationCallback?.();
        closeModal();
    };

    const actionButtons: IActionButton[] = [
        {
            appearance: 'ghost',
            label: 'Ok',
            color: 'blue',
            action: () => confirm(true),
        },
        {
            appearance: 'ghost',
            label: 'Cancel',
            color: 'red',
            action: () => confirm(false),
        },
    ];
    return (
        <Modal backdrop='static' className='modal confirmation-modal' size={'sm'} open={open}>
            <Modal.Body className='confirmation-modal-body'>
                <div>This action is irreversible. Are you sure?</div>
                <ActionButtonCollection className='confirmation-buttons' buttons={actionButtons} />
            </Modal.Body>
        </Modal>
    );
};

export default ConfirmationModal;
