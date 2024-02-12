import { FlexboxGrid } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import ActionButton from '../input/ActionButton';

interface IProps {
    colspan: number;
    headerButtons?: IActionButton[];
}

const ListingHeaderRowButtons = ({ colspan, headerButtons }: IProps) => {
    return (
        <FlexboxGrid.Item key='buttons' className='button-group' colspan={colspan}>
            {headerButtons?.map((button) => (
                <ActionButton appearance={button.appearance} action={button.action} />
            ))}
        </FlexboxGrid.Item>
    );
};

export default ListingHeaderRowButtons;
