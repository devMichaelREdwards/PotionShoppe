import { FlexboxGrid } from 'rsuite';

interface IProps {
    columns: number;
}

const EmptyColumns = ({ columns }: IProps) => {
    return <FlexboxGrid.Item colspan={columns}></FlexboxGrid.Item>;
};

export default EmptyColumns;
