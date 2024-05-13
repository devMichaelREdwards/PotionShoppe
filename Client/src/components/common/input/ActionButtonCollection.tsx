import { FlexboxGrid } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import ActionButton from './ActionButton';
import { nanoid } from 'nanoid';
import { IData } from '../../../types/IData';

interface IProps {
    colspan?: number;
    className?: string;
    buttons?: IActionButton[];
    data?: IData;
    remove?: () => void;
}

const ActionButtonCollection = ({ colspan, className, buttons, data, remove }: IProps) => {
    return (
        <FlexboxGrid.Item className={`${className} button-group`} key='buttons' colspan={colspan ?? 24}>
            {buttons?.map((b) => {
                return (
                    <ActionButton
                        key={nanoid()}
                        color={b.color}
                        appearance={b.appearance}
                        label={b.label}
                        icon={b.icon}
                        action={b.action}
                        arg={b.argKey ? data?.[b.argKey] : undefined}
                    />
                );
            })}
            {remove && <ActionButton key={nanoid()} color={'red'} appearance={'ghost'} label={'Delete'} action={remove} />}
        </FlexboxGrid.Item>
    );
};

export default ActionButtonCollection;
