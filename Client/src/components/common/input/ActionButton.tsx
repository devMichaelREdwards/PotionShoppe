import { Button } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import { IData } from '../../../types/IData';
import { ActiveIcon, InactiveIcon } from '../image/Icon';

const ActionButton = ({ appearance, color, label, icon, action, arg }: IActionButton) => {
    return (
        <Button className={`action-button ${color}`} appearance={appearance} color={color} onClick={() => action?.(arg)}>
            {icon}
            {label}
        </Button>
    );
};

export const ActionToggle = ({ currentValue, action, refresh, arg }: IActionButton) => {
    const data: IData = {
        id: arg as number,
        currentValue,
    };

    const onClick = async () => {
        await action?.(data);
        refresh?.();
    };

    return (
        <Button className='action-toggle' onClick={onClick}>
            {currentValue ? <ActiveIcon /> : <InactiveIcon />}
        </Button>
    );
};

export default ActionButton;
