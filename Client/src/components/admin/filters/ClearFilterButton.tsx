import { BroomIcon } from '../../common/image/Icon';
import ActionButton from '../../common/input/ActionButton';

interface IProps {
    clearFiltersClick: () => void;
}

const ClearFilterButton = ({ clearFiltersClick }: IProps) => {
    return (
        <div className='clear-filters-button'>
            <ActionButton icon={<BroomIcon />} color='purple' tooltip='Clear filters' action={clearFiltersClick} />
        </div>
    );
};

export default ClearFilterButton;
