import axios from '../../../../../api/axios';
import useAuth from '../../../../../hooks/useAuth';
import { IActionButton, IListingColumn } from '../../../../../types/IListing';
import { PotionIcon } from '../../../../common/image/Icon';
import Listing from '../../../../common/listing/Listing';

const EffectListing = () => {
    const { user } = useAuth();
    // Set filters here
    const columns: IListingColumn[] = [
        {
            align: 'left',
            label: 'Name',
            dataKey: 'name',
            colspan: 4,
        },
        {
            align: 'left',
            label: 'Value',
            dataKey: 'value',
            colspan: 2,
        },
        {
            align: 'left',
            label: 'Duration',
            dataKey: 'duration',
            colspan: 2,
        },
        {
            align: 'left',
            label: 'Description',
            dataKey: 'description',
            colspan: 13,
        },
    ];

    const rowButtons: IActionButton[] = [
        {
            appearance: 'ghost',
            label: 'edit',
            color: 'violet',
            icon: <PotionIcon />,
            argKey: 'effectId',
            action: (id) => {
                console.log(id);
            },
        },
    ];

    const remove = async (selected: number[]) => {
        await axios.post('effect/remove', selected, user?.authConfig);
    };

    return (
        <div className='listing'>
            <Listing id='effectId' columns={columns} route={'effect/listing'} remove={remove} rowButtons={rowButtons} />
        </div>
    );
};

export default EffectListing;
