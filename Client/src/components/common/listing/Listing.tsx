import { nanoid } from 'nanoid';
import { Button, FlexboxGrid, List } from 'rsuite';
import { useData } from '../../../hooks/useData';
import { useEffect, useState } from 'react';
import ListingRow from './ListingRow';
import { IData } from '../../../types/IData';
import { IListingColumn } from '../../../types/IListing';

interface IProps {
    id?: string;
    route: string;
    columns: IListingColumn[];
    remove?: () => void;
}

const Listing = ({ id, route, columns, remove }: IProps) => {
    const idKey = id ?? route + 'Id';
    const { data, loading, error, refresh } = useData(route);
    const [selected, setSelected] = useState<number[]>([]);
    const [draw, setDraw] = useState(0);
    const handleCheckboxClick = (id: number) => {
        if (selected.includes(id)) {
            const newSelected = selected.filter((inArr) => {
                return inArr !== id ? id : null;
            });
            setSelected([...newSelected]);
        } else {
            selected.push(id);
            setSelected([...selected]);
        }
    };

    const handleRemoveClick = () => {
        remove?.();
        setDraw(draw + 1);
    };

    useEffect(() => {
        refresh();

        // Do not need refresh here
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [draw]);

    if (loading) return <>Loading Screen</>;

    if (error || !Array.isArray(data)) return <>Error Screen</>;
    return (
        <List className='panel' hover>
            <ListingHeaderRow key={'Header'} columns={columns} remove={remove ? handleRemoveClick : undefined} />
            {data.map((row: IData) => {
                return (
                    <ListingRow
                        key={nanoid()}
                        columns={columns}
                        id={row[idKey] as number}
                        data={row}
                        checked={selected.includes(row[idKey] as number)}
                        handleCheckboxClick={handleCheckboxClick}
                    />
                );
            })}
        </List>
    );
};

interface IEmptyColumnsProps {
    columns: number;
}

export const EmptyColumns = ({ columns }: IEmptyColumnsProps) => {
    return <FlexboxGrid.Item colspan={columns}></FlexboxGrid.Item>;
};

interface IListingHeaderRowProps {
    columns: IListingColumn[];
    remove?: () => void;
}

const ListingHeaderRow = ({ columns, remove }: IListingHeaderRowProps) => {
    let colsLeft = 22; //24 - 2 for checkbox col
    return (
        <List.Item className='listing-header'>
            <FlexboxGrid>
                <EmptyColumns key={nanoid()} columns={2} />
                {columns.map((col) => {
                    colsLeft -= col.colspan;
                    return (
                        <FlexboxGrid.Item key={col.dataKey} colspan={col.colspan}>
                            {col.label}
                        </FlexboxGrid.Item>
                    );
                })}

                <ListingHeaderRowButtons colspan={colsLeft} remove={remove} />
            </FlexboxGrid>
        </List.Item>
    );
};

interface IListingHeaderRowButtonsProps {
    colspan: number;
    remove?: () => void;
}

const ListingHeaderRowButtons = ({ colspan, remove }: IListingHeaderRowButtonsProps) => {
    return (
        <>
            {remove && (
                <FlexboxGrid.Item key='buttons' className='button-group' colspan={colspan}>
                    <Button onClick={remove} color='red' appearance='primary'>
                        Delete
                    </Button>
                </FlexboxGrid.Item>
            )}
        </>
    );
};

export default Listing;
