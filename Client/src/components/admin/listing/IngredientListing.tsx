import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IActionButton, ICollectionObject, IListingColumn } from '../../../types/IListing';
import { IngredientIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';
import CollectionColumn from '../../common/listing/columns/CollectionColumn';
import ImageColumn from '../../common/listing/columns/ImageColumn';

const IngredientListing = () => {
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
            label: 'Effect',
            dataKey: 'effect',
            colspan: 4,
            component: (effect: unknown) => <CollectionColumn collection={[effect as ICollectionObject]} />,
        },
        {
            align: 'center',
            label: 'Cost',
            dataKey: 'cost',
            colspan: 2,
        },
        {
            align: 'center',
            label: 'Price',
            dataKey: 'price',
            colspan: 2,
        },
        {
            align: 'center',
            label: 'In Stock',
            dataKey: 'currentStock',
            colspan: 2,
        },
    ];

    const rowButtons: IActionButton[] = [
        {
            appearance: 'ghost',
            label: 'edit',
            color: 'violet',
            icon: <IngredientIcon />,
            argKey: 'IngredientId',
            action: (id) => {
                console.log(id);
            },
        },
    ];

    const remove = async (selected: number[]) => {
        await axios.post('Ingredient/remove', selected, user?.authConfig);
    };

    return <Listing id='ingredientId' columns={columns} route={'ingredient/listing'} remove={remove} rowButtons={rowButtons} />;
};

export default IngredientListing;
