import { nanoid } from 'nanoid';
import { List } from 'rsuite';
import { useData } from '../../../hooks/useData';
import { useEffect, useState } from 'react';
import ListingRow from './ListingRow';
import { IData } from '../../../types/IData';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import ListingHeaderRow from './ListingHeaderRow';
import Pagination from '../input/Pagination';
import ConfirmationModal from '../../admin/modal/ConfirmationModal';

interface IProps {
    id?: string;
    route: string;
    columns: IListingColumn[];
    headerButtons?: IActionButton[];
    rowButtons?: IActionButton[];
    filterString?: string;
    remove?: (selected: number[]) => void;
}

export enum SortOrder {
    ascending = 'asc',
    descending = 'desc',
    default = '',
}

const Listing = ({ id, route, columns, headerButtons, rowButtons, filterString, remove }: IProps) => {
    const idKey = id ?? route + 'Id';
    const [selected, setSelected] = useState<number[]>([]);
    const [draw, setDraw] = useState(0);
    const [page, setPage] = useState(1);
    const [limit, setLimit] = useState(20);
    const [sort, setSort] = useState('');
    const [sortOrder, setSortOrder] = useState(SortOrder.default);
    const { data, loading, error, refresh, setLoading } = useData(
        route + `?page=${page}&limit=${limit}&sort=${sort}&order=${sortOrder}&${filterString ?? ''}`
    );
    const [open, setOpen] = useState(false);
    const openModal = () => {
        setOpen(true);
    };
    const closeModal = () => {
        setOpen(false);
    };
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
        openModal();
    };

    const handleRemoveConfirmed = async () => {
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

    const handleSortClick = (col: string) => {
        setLoading(true);
        // If the col is the current sort col
        if (col === sort) {
            // Default -> Ascending -> Descending
            if (sortOrder === SortOrder.default) {
                setSortOrder(SortOrder.ascending);
            }

            if (sortOrder === SortOrder.ascending) {
                setSortOrder(SortOrder.descending);
            }

            if (sortOrder === SortOrder.descending) {
                setSortOrder(SortOrder.default);
            }

            return;
        }

        // If the col is sortable
        const colSortable = columns.find((c) => c.dataKey == col && c.sortable);
        if (colSortable) {
            setSort(colSortable.dataKey);
            setSortOrder(SortOrder.ascending);
        }
    };

    const refreshList = () => {
        setDraw(draw + 1);
    };

    useEffect(() => {
        refresh();
    }, [draw]);

    if (loading) return <>Loading Screen</>;

    if (error || !Array.isArray(data)) return <>Error Screen</>;

    return (
        <>
            <List className='panel listing'>
                <ListingHeaderRow
                    key={'Header'}
                    columns={columns}
                    headerButtons={headerButtons}
                    sortCol={sort}
                    sortOrder={sortOrder}
                    sort={handleSortClick}
                    remove={remove ? handleRemoveClick : undefined}
                />
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
                            refresh={refreshList}
                        />
                    );
                })}
            </List>
            <ConfirmationModal open={open} closeModal={closeModal} confirmationCallback={handleRemoveConfirmed} />
            <Pagination page={page} limit={limit} onPageChange={handlePageChange} onLimitChange={handleLimitChange} />
        </>
    );
};

export default Listing;
