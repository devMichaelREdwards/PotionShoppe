import { nanoid } from 'nanoid';
import { ICollectionObject } from '../../../../types/IListing';
import Color from 'color';

interface IProps {
    collection: ICollectionObject[];
}

const CollectionColumn = ({ collection }: IProps) => {
    return (
        <div className='collection-column'>
            {collection.map((data: ICollectionObject) => {
                console.log(data);
                return <CollectionObject key={nanoid()} {...data} />;
            })}
        </div>
    );
};

const CollectionObject = ({ title, color }: ICollectionObject) => {
    const colorData = Color(color);
    return (
        <div className={`pill ${colorData.isLight() ? 'light' : 'dark'}`} style={{ backgroundColor: `${color ?? 'grey'}` }}>
            {title}
        </div>
    );
};

export default CollectionColumn;
