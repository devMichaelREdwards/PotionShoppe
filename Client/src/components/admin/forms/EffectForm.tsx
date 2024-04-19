import ActionButton from '../../common/input/ActionButton';

interface IProps {
    toggleEdit: (active: boolean) => void;
}

const EffectForm = ({ toggleEdit }: IProps) => {
    return (
        <>
            <ActionButton
                appearance='ghost'
                label='Back to list'
                color='violet'
                action={() => {
                    toggleEdit(false);
                }}
            />
        </>
    );
};

export default EffectForm;
