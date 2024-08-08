import { FlexboxGrid } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import ActionButton, { ActionToggle } from './ActionButton';
import { nanoid } from 'nanoid';
import { IData } from '../../../types/IData';
import { TrashIcon } from '../image/Icon';

interface IProps {
    colspan?: number;
    className?: string;
    buttons?: IActionButton[];
    data?: IData;
    removeTooltip?: string;
    disabled?: boolean;
    refresh?: () => void;
    remove?: () => void;
}

const ActionButtonCollection = ({ colspan, className, buttons, data, refresh, remove, removeTooltip, disabled }: IProps) => {
    return (
        <FlexboxGrid.Item className={`${className} button-group`} key='buttons' colspan={colspan ?? 24}>
            {buttons?.map((b) => {
                return b.isToggle ? (
                    <ActionToggle
                        key={nanoid()}
                        currentValue={data?.['active']}
                        action={b.action}
                        arg={b.argKey ? data?.[b.argKey] : undefined}
                        refresh={refresh}
                        tooltip={b.tooltip}
                        placement={b.placement}
                    />
                ) : (
                    <ActionButton
                        key={nanoid()}
                        color={b.color}
                        appearance={b.appearance}
                        label={b.label}
                        icon={b.icon}
                        action={b.action}
                        refresh={!b.noRefresh ? refresh : undefined}
                        arg={b.argKey ? data?.[b.argKey] : undefined}
                        tooltip={b.tooltip}
                        placement={b.placement}
                        disabled={disabled}
                    />
                );
            })}
            {remove && <ActionButton key={nanoid()} color={'red'} icon={<TrashIcon />} action={remove} tooltip={removeTooltip} placement='top' />}
        </FlexboxGrid.Item>
    );
};

export default ActionButtonCollection;
