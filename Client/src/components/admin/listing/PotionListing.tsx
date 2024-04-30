import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IIngredientFilters } from '../../../types/IFilter';
import { IActionButton, ICollectionObject, IListingColumn } from '../../../types/IListing';
import { PotionIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';
import CollectionColumn from '../../common/listing/columns/CollectionColumn';
import ImageColumn from '../../common/listing/columns/ImageColumn';

interface IProps {
    filters: IIngredientFilters;
}

const PotionListing = ({ filters }: IProps) => {
    const { user } = useAuth();
    // Set filters here
    const columns: IListingColumn[] = [
        // 21
        {
            align: 'center',
            label: 'Image',
            dataKey: 'image',
            colspan: 2,
            component: (src: unknown) => <ImageColumn src={src as string} />,
        },
        {
            align: 'center',
            label: 'Name',
            dataKey: 'name',
            colspan: 4,
        },
        {
            align: 'center',
            label: 'Description',
            dataKey: 'description',
            colspan: 4,
        },
        {
            align: 'center',
            label: 'Effects',
            dataKey: 'potionEffects',
            colspan: 4,
            component: (collection: unknown) => <CollectionColumn collection={collection as ICollectionObject[]} />,
        },
        {
            align: 'center',
            label: 'Cost',
            dataKey: 'cost',
            sortable: true,
            colspan: 2,
        },
        {
            align: 'center',
            label: 'Price',
            dataKey: 'price',
            sortable: true,
            colspan: 2,
        },
        {
            align: 'center',
            label: 'In Stock',
            dataKey: 'currentStock',
            sortable: true,
            colspan: 2,
        },
    ];

    const rowButtons: IActionButton[] = [
        {
            appearance: 'ghost',
            label: 'edit',
            color: 'violet',
            icon: <PotionIcon />,
            argKey: 'PotionId',
            action: (id) => {
                console.log(id);
            },
        },
    ];

    const remove = async (selected: number[]) => {
        await axios.post('Potion/remove', selected, user?.authConfig);
    };

    const buildFilterString = (filters: IIngredientFilters) => {
        let addFilters = false;
        let filterString = '';
        if (filters.name) {
            addFilters = true;
            filterString += `name=${filters.name}`;
        }

        if (filters.effects !== undefined && filters.effects.length > 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            let idString = '';
            filters.effects.forEach((eff, i) => {
                idString += eff;
                if (i < filters.effects!.length - 1) {
                    idString += ',';
                }
            });
            filterString += `effect=${idString}`;
        }

        if (filters.cmin !== undefined && filters.cmin > 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `cmin=${filters.cmin}`;
        }

        if (filters.cmax !== undefined && filters.cmax > 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `cmax=${filters.cmax}`;
        }

        if (filters.pmin !== undefined && filters.pmin > 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `pmin=${filters.pmin}`;
        }

        if (filters.pmax !== undefined && filters.pmax > 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `pmax=${filters.pmax}`;
        }

        if (filters.instock !== undefined && filters.instock == true) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            filterString += `instock`;
        }

        return addFilters ? filterString : '';
    };

    return (
        <Listing
            id='potionId'
            columns={columns}
            route={'potion/listing'}
            remove={remove}
            rowButtons={rowButtons}
            filterString={buildFilterString(filters)}
        />
    );
};

export default PotionListing;
