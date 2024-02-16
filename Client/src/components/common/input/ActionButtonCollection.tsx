import { FlexboxGrid } from 'rsuite';
import { IActionButton } from '../../../types/IListing';
import ActionButton from './ActionButton';
import { nanoid } from 'nanoid';
import { IData } from '../../../types/IData';

interface IProps {
    colspan: number;
    buttons?: IActionButton[];
    data?: IData;
    remove?: () => void;
}

const ActionButtonCollection = ({ colspan, buttons, data, remove }: IProps) => {
    return (
        <FlexboxGrid.Item className='listing-item button-group' key='buttons' colspan={colspan}>
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
