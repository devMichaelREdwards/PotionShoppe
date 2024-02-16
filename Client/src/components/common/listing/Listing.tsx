import { nanoid } from 'nanoid';
import { List } from 'rsuite';
import { useData } from '../../../hooks/useData';
import { useEffect, useState } from 'react';
import ListingRow from './ListingRow';
import { IData } from '../../../types/IData';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import ListingHeaderRow from './ListingHeaderRow';

interface IProps {
    id?: string;
    route: string;
    columns: IListingColumn[];
    headerButtons?: IActionButton[];
    rowButtons?: IActionButton[];
    remove?: (selected: number[]) => void;
}

const Listing = ({ id, route, columns, headerButtons, rowButtons, remove }: IProps) => {
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

    const handleRemoveClick = async () => {
        await remove?.(selected);
        setSelected([]);
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
    );
};

export default Listing;
