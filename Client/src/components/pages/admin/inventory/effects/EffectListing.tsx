import axios from '../../../../../api/axios';
import useAuth from '../../../../../hooks/useAuth';
import { IListingColumn } from '../../../../../types/IListing';
import Listing from '../../../../common/listing/Listing';

const EffectListing = () => {
    const { user } = useAuth();
    const columns: IListingColumn[] = [
        {
            align: 'left',
            label: 'Name',
            dataKey: 'name',
            colspan: 5,
        },
        {
            align: 'left',
            label: 'Value',
            dataKey: 'value',
            colspan: 3,
        },
        {
            align: 'left',
            label: 'Duration',
            dataKey: 'duration',
            colspan: 3,
        },
        {
            align: 'left',
            label: 'Description',
            dataKey: 'description',
            colspan: 3,
        },
    ];

    const remove = async (selected: number[]) => {
        await axios.post('effect/remove', selected, user?.authConfig);
    };

    return (
        <div className='listing'>
            <Listing id='effectId' columns={columns} route={'effect/listing'} remove={remove} />
        </div>
    );
};

export default EffectListing;
