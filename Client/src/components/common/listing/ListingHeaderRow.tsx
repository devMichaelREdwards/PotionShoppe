import { nanoid } from 'nanoid';
import { List, FlexboxGrid } from 'rsuite';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import EmptyColumns from './columns/EmptyColumns';
import ActionButtonCollection from '../input/ActionButtonCollection';
import { SortIcon } from '../image/Icon';
import { SortOrder } from './Listing';

interface IListingHeaderRowProps {
    columns: IListingColumn[];
    headerButtons?: IActionButton[];
    sortCol?: string;
    sortOrder?: SortOrder;
    removeTooltip?: string;
    ignoreCheckbox?: boolean;
    sort?: (col: string) => void;
    remove?: () => void;
}

const ListingHeaderRow = ({ columns, headerButtons, sortCol, sortOrder, sort, remove, removeTooltip, ignoreCheckbox }: IListingHeaderRowProps) => {
    let colsLeft = 24 - (ignoreCheckbox ? 0 : 1);
    return (
        <List.Item className='listing-row listing-header'>
            <FlexboxGrid>
                {!ignoreCheckbox && <EmptyColumns key={nanoid()} columns={1} />}
                {columns.map((col) => {
                    colsLeft -= col.colspan;
                    return (
                        <FlexboxGrid.Item
                            className='listing-item'
                            key={col.dataKey}
                            colspan={col.colspan}
                            onClick={() => {
                                col.sortable && sort?.(col.dataKey);
                            }}
                        >
                            {col.label}
                            {col.sortable && <SortIcon sort={sortCol === col.dataKey ? sortOrder ?? SortOrder.ascending : SortOrder.default} />}
                        </FlexboxGrid.Item>
                    );
                })}

                <ActionButtonCollection
                    colspan={colsLeft}
                    className='listing-item'
                    buttons={headerButtons}
                    remove={remove}
                    removeTooltip={removeTooltip}
                />
            </FlexboxGrid>
        </List.Item>
    );
};

export default ListingHeaderRow;
