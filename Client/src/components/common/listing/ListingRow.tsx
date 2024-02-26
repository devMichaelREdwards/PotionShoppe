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
    let colsLeft = 23; //24 - 1 for checkbox col
    return (
        <List.Item key={nanoid()} className='listing-row'>
            <FlexboxGrid>
                <FlexboxGrid.Item className='listing-item' key='id' colspan={1}>
                    <IDCheckBox id={id} checked={checked} handleCheckboxClick={handleCheckboxClick} />
                </FlexboxGrid.Item>
                {columns.map((col) => {
                    colsLeft -= col.colspan;
                    if (col.component) {
                        return (
                            <FlexboxGrid.Item className='listing-item' key={col.dataKey} colspan={col.colspan}>
                                {col.component(data[col.dataKey])}
                            </FlexboxGrid.Item>
                        );
                    }
                    return (
                        <FlexboxGrid.Item className='listing-item' key={col.dataKey} colspan={col.colspan}>
                            <>{data[col.dataKey] ?? ''}</>
                        </FlexboxGrid.Item>
                    );
                })}
                <ActionButtonCollection data={data} colspan={colsLeft} buttons={rowButtons} />
            </FlexboxGrid>
        </List.Item>
    );
};

export default ListingRow;
