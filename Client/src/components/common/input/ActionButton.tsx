import { Button, Tooltip, Whisper } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import { IData } from '../../../types/IData';
import { ActiveIcon, InactiveIcon } from '../image/Icon';

const ActionButton = ({ appearance, color, label, tooltip, placement, icon, action, refresh, arg }: IActionButton) => {
    return (
        <Whisper placement={placement ?? 'top'} speaker={<Tooltip>{tooltip}</Tooltip>} disabled={!tooltip}>
            <Button
                className={`action-button ${color}`}
                appearance={appearance}
                onClick={async () => {
                    await action?.(arg);
                    refresh?.();
                }}
            >
                {icon}
                {label}
            </Button>
        </Whisper>
    );
};

export const ActionToggle = ({ currentValue, action, refresh, tooltip, placement, arg }: IActionButton) => {
    const data: IData = {
        id: arg as number,
        currentValue,
    };

    const onClick = async () => {
        await action?.(data);
        refresh?.();
    };

    return (
        <Whisper placement={placement ?? 'top'} speaker={<Tooltip>{tooltip}</Tooltip>} disabled={!tooltip}>
            <Button className='action-toggle' onClick={onClick}>
                {currentValue ? <ActiveIcon /> : <InactiveIcon />}
            </Button>
        </Whisper>
    );
};

export default ActionButton;
