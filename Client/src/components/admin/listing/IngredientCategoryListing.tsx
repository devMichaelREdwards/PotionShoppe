import { Message, toaster } from 'rsuite';
import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { CategoriesIcon, TrashIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';

const IngredientCategoryListing = () => {
    const { user } = useAuth();
    const columns: IListingColumn[] = [
        // 21
        {
            align: 'center',
            label: 'Category',
            dataKey: 'title',
            colspan: 20,
        },
    ];

    const headerButtons: IActionButton[] = [
        {
            color: 'green',
            tooltip: 'Add Category',
            icon: <CategoriesIcon />,
            action: () => {},
        },
    ];

    const rowButtons: IActionButton[] = [
        {
            color: 'red',
            tooltip: 'Remove Category',
            argKey: 'ingredientCategoryId',
            icon: <TrashIcon />,
            action: async (id) => {
                await remove(id as number);
            },
        },
    ];

    const remove = async (id: number) => {
        const post = {
            ingredientCategoryId: id,
        };

        const response = await axios.post(`ingredientcategory/remove/`, post, user?.authConfig);
        console.log(response);
        if (response.data) {
            toaster.push(<Message type='success'>Removed Category</Message>, { duration: 5000 });
        } else {
            toaster.push(<Message type='error'>Something went wrong!</Message>, { duration: 5000 });
        }
    };

    return (
        <Listing
            id='ingredientCategoryId'
            columns={columns}
            route={'ingredientcategory'}
            headerButtons={headerButtons}
            rowButtons={rowButtons}
            ignoreCheckbox
            ignorePagination
        />
    );
};

export default IngredientCategoryListing;
