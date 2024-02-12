import { Button, Checkbox, FlexboxGrid, List } from 'rsuite';
import { IData } from '../../../types/IData';
import { IListingColumn } from '../../../types/IListing';
import { nanoid } from 'nanoid';

interface IProps {
    id: number;
    data: IData;
    checked: boolean;
    columns: IListingColumn[];
    handleCheckboxClick: (id: number) => void;
}

const ListingRow = ({ id, data, checked, columns, handleCheckboxClick }: IProps) => {
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
                        <FlexboxGrid.Item key={col.dataKey} colspan={col.colspan}>
                            <>{data[col.dataKey] ?? ''}</>
                        </FlexboxGrid.Item>
                    );
                })}
                <ListingRowButtons id={data.id} colspan={colsLeft} />
            </FlexboxGrid>
        </List.Item>
    );
};

export default ListingRow;

interface IIDCheckBox {
    id: number;
    checked: boolean;
    handleCheckboxClick: (id: number) => void;
}

const IDCheckBox = ({ id, checked, handleCheckboxClick }: IIDCheckBox) => {
    return (
        <Checkbox
            value={id}
            onChange={() => {
                return handleCheckboxClick(id);
            }}
            checked={checked}
        />
    );
};

interface IRowButtons {
    id: number;
    colspan: number;
}

const ListingRowButtons = ({ id, colspan }: IRowButtons) => {
    return (
        <FlexboxGrid.Item key='buttons' className='button-group' colspan={colspan}>
            <Button color='blue' appearance='primary'>
                Edit
            </Button>
        </FlexboxGrid.Item>
    );
};
