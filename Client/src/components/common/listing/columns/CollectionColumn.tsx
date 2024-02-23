import { nanoid } from 'nanoid';
import { ICollectionObject } from '../../../../types/IListing';
import Color from 'color';
import { Tooltip, Whisper } from 'rsuite';

interface IProps {
    collection: ICollectionObject[];
}

const CollectionColumn = ({ collection }: IProps) => {
    return (
        <div className='collection-column'>
            {collection.map((data: ICollectionObject) => {
                return <Pill key={nanoid()} {...data} />;
            })}
        </div>
    );
};

const Pill = ({ title, color }: ICollectionObject) => {
    try {
        const colorData = Color(color);
        return (
            <div className={`pill ${colorData.isLight() ? 'light' : 'dark'}`} style={{ backgroundColor: `${color ?? 'grey'}` }}>
                {title}
            </div>
        );
    } catch (e) {
        // If the color string cannot be parsed
        return (
            <Whisper speaker={<Tooltip>Invalid color!</Tooltip>}>
                <div className={`pill light error`} style={{ backgroundColor: `${'grey'}` }}>
                    {title}
                    <span>!</span>
                </div>
            </Whisper>
        );
    }
};

export default CollectionColumn;
