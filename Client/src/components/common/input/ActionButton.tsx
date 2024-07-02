import { Button } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import { IData } from '../../../types/IData';

const ActionButton = ({ appearance, color, label, icon, action, arg }: IActionButton) => {
    return (
        <Button appearance={appearance} color={color} onClick={() => action?.(arg)}>
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

    return <Button onClick={onClick}>{currentValue ? 'Checkmark' : 'X Mark'}</Button>;
};

export default ActionButton;
