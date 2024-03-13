import { Checkbox } from 'rsuite';

interface IIDCheckBox {
    id: number;
    checked: boolean;
    handleCheckboxClick: (id: number) => void;
}

const IDCheckBox = ({ id, checked, handleCheckboxClick }: IIDCheckBox) => {
    return (
        <Checkbox
            className='listing-checkbox'
            id={`row-${id}`}
            value={id}
            onChange={() => {
                return handleCheckboxClick(id);
            }}
            checked={checked}
        />
    );
};

export default IDCheckBox;
