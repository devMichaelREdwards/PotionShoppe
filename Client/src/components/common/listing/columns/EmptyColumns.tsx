import { FlexboxGrid } from 'rsuite';

interface IProps {
    columns: number;
}

const EmptyColumns = ({ columns }: IProps) => {
    return <FlexboxGrid.Item className='listing-item' colspan={columns}></FlexboxGrid.Item>;
};

export default EmptyColumns;
