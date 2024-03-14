import { nanoid } from 'nanoid';
import { List } from 'rsuite';
import { useData } from '../../../hooks/useData';
import { useEffect, useState } from 'react';
import ListingRow from './ListingRow';
import { IData } from '../../../types/IData';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import ListingHeaderRow from './ListingHeaderRow';
import Pagination from '../input/Pagination';

interface IProps {
    id?: string;
    route: string;
    columns: IListingColumn[];
    headerButtons?: IActionButton[];
    rowButtons?: IActionButton[];
    filterString?: string;
    remove?: (selected: number[]) => void;
}

const Listing = ({ id, route, columns, headerButtons, rowButtons, filterString, remove }: IProps) => {
    const idKey = id ?? route + 'Id';
    const [selected, setSelected] = useState<number[]>([]);
    const [draw, setDraw] = useState(0);
    const [page, setPage] = useState(1);
    const [limit, setLimit] = useState(20);
    const { data, loading, error, refresh } = useData(route + `?page=${page}&limit=${limit}&${filterString ?? ''}`);
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

    const handleRemoveClick = async () => {
        await remove?.(selected);
        setSelected([]);
        setDraw(draw + 1);
    };

    const handlePageChange = (newPage: number) => {
        if (newPage < 1) return;
        setPage(newPage);
    };

    const handleLimitChange = (newLimit: number) => {
        if (newLimit < 1) return;
        setLimit(newLimit);
    };

    useEffect(() => {
        refresh();
    }, [draw]);

    if (loading) return <>Loading Screen</>;

    if (error || !Array.isArray(data)) return <>Error Screen</>;

    return (
        <>
            <List className='panel listing'>
                <ListingHeaderRow key={'Header'} columns={columns} headerButtons={headerButtons} remove={remove ? handleRemoveClick : undefined} />
                {data.map((row: IData) => {
                    return (
                        <ListingRow
                            key={nanoid()}
                            columns={columns}
                            id={row[idKey] as number}
                            data={row}
                            checked={selected.includes(row[idKey] as number)}
                            handleCheckboxClick={handleCheckboxClick}
                            rowButtons={rowButtons}
                        />
                    );
                })}
            </List>
            <Pagination page={page} limit={limit} onPageChange={handlePageChange} onLimitChange={handleLimitChange} />
        </>
    );
};

export default Listing;
