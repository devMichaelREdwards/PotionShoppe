import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IEffectFilters } from '../../../types/IFilter';
import { IActionButton, ICollectionObject, IListingColumn } from '../../../types/IListing';
import { PotionIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';
import CollectionColumn from '../../common/listing/columns/CollectionColumn';

interface IProps {
    filters: IEffectFilters;
}

const EffectListing = ({ filters }: IProps) => {
    const { user } = useAuth();
    // Set filters here
    const columns: IListingColumn[] = [
        {
            align: 'center',
            label: 'Name',
            dataKey: 'name',
            colspan: 4,
        },
        {
            align: 'center',
            label: 'Value',
            dataKey: 'value',
            colspan: 2,
        },
        {
            align: 'center',
            label: 'Duration',
            dataKey: 'duration',
            colspan: 2,
        },
        {
            align: 'center',
            label: 'Color',
            dataKey: 'color',
            colspan: 2,
            component: (color: unknown) => <CollectionColumn collection={[color as ICollectionObject]} />,
        },
        {
            align: 'center',
            label: 'Description',
            dataKey: 'description',
            colspan: 10,
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

    const buildFilterString = (filters: IEffectFilters) => {
        let addFilters = false;
        let filterString = '?';
        if (filters.name) {
            addFilters = true;
            filterString += `name=${filters.name}`;
        }

        if (filters.vmin !== undefined && filters.vmin >= 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `vmin=${filters.vmin}`;
        }

        if (filters.vmax !== undefined && filters.vmax >= 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `vmax=${filters.vmax}`;
        }

        if (filters.dmin !== undefined && filters.dmin >= 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `dmin=${filters.dmin}`;
        }

        if (filters.dmax !== undefined && filters.dmax >= 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `dmax=${filters.dmax}`;
        }

        return addFilters ? filterString : '';
    };

    return <Listing id='effectId' columns={columns} route={`effect/listing${buildFilterString(filters)}`} remove={remove} rowButtons={rowButtons} />;
};

export default EffectListing;
