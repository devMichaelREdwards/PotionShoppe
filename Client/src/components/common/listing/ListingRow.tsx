import { FlexboxGrid, List } from 'rsuite';
import { IData } from '../../../types/IData';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { nanoid } from 'nanoid';
import IDCheckBox from './IdCheckBox';
import ActionButtonCollection from '../input/ActionButtonCollection';

interface IProps {
    id: number;
    data: IData;
    checked: boolean;
    columns: IListingColumn[];
    rowButtons?: IActionButton[];
    handleCheckboxClick: (id: number) => void;
}

const ListingRow = ({ id, data, checked, columns, rowButtons, handleCheckboxClick }: IProps) => {
    if (!id) return null;
    let colsLeft = 22; //24 - 2 for checkbox col
    return (
        <List.Item key={nanoid()} className='listing-row'>
            <FlexboxGrid>
                <FlexboxGrid.Item key='id' colspan={2}>
                    <IDCheckBox id={id} checked={checked} handleCheckboxClick={handleCheckboxClick} />
                </FlexboxGrid.Item>
                {columns.map((col) => {
                    colsLeft -= col.colspan;
                    return (
                        <FlexboxGrid.Item className='vertical-center-text' key={col.dataKey} colspan={col.colspan}>
                            <div>
                                <>{data[col.dataKey] ?? ''}</>
                            </div>
                        </FlexboxGrid.Item>
                    );
                })}
                <ActionButtonCollection data={data} colspan={colsLeft} buttons={rowButtons} />
            </FlexboxGrid>
        </List.Item>
    );
};

export default ListingRow;
