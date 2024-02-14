import { Button } from 'rsuite';
import { IActionButton } from '../../../types/IListing';

const ActionButton = ({ appearance, color, label, icon, action, arg }: IActionButton) => {
    return (
        <Button appearance={appearance} color={color} onClick={() => action(arg)}>
            {icon}
            {label}
        </Button>
    );
};

export default ActionButton;
