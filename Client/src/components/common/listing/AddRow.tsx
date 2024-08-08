import { FlexboxGrid, List } from 'rsuite';
import { IData } from '../../../types/IData';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { nanoid } from 'nanoid';
import IDCheckBox from './IdCheckBox';
import ActionButtonCollection from '../input/ActionButtonCollection';
import EditColumn from './columns/EditColumn';

interface IProps {
    columns: IListingColumn[];
    rowButtons?: IActionButton[];
    ignoreCheckbox?: boolean;
    onSubmit: (newValue: string) => Promise<void>;
}

const AddRow = ({ columns, rowButtons, onSubmit, ignoreCheckbox }: IProps) => {
    let colsLeft = 24 - (ignoreCheckbox ? 0 : 1);
    const data = {} as IData;
    return (
        <List.Item key={nanoid()} className='listing-row'>
            <FlexboxGrid>
                {!ignoreCheckbox && (
                    <FlexboxGrid.Item className='listing-item' key='id' colspan={1}>
                        <IDCheckBox
                            id={0}
                            checked={false}
                            handleCheckboxClick={() => {
                                // Do nothing, maybe disable?
                            }}
                        />
                    </FlexboxGrid.Item>
                )}

                {columns.map((col) => {
                    colsLeft -= col.colspan;

                    return (
                        <FlexboxGrid.Item className='listing-item' key={col.dataKey} colspan={col.colspan}>
                            <EditColumn
                                edit={true}
                                data={data}
                                name={'new-row-input'}
                                submitting={false}
                                submitCallback={async (newValue) => {
                                    await onSubmit(newValue);
                                }}
                            />
                        </FlexboxGrid.Item>
                    );
                })}
                <ActionButtonCollection className={'listing-item'} data={data} colspan={colsLeft} buttons={rowButtons} disabled />
            </FlexboxGrid>
        </List.Item>
    );
};

export default AddRow;
