import { Message, toaster } from 'rsuite';
import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { CategoriesIcon, QuillIcon, TrashIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';
import { useState } from 'react';
import { IData } from '../../../types/IData';
import { useSubmit } from '../../../hooks/useSubmit';
import EditColumn from '../../common/listing/columns/EditColumn';
import AddRow from '../../common/listing/AddRow';

interface IProps {
    refresher: () => void;
}

const IngredientCategoryListing = ({ refresher }: IProps) => {
    const { user } = useAuth();
    const [editId, setEditId] = useState<number>();
    const [addRow, setAddRow] = useState(false);
    const [draw, setDraw] = useState(0);
    const { submitting, submitForm } = useSubmit(
        'ingredientcategory',
        addRow ? 'Category Added' : 'Category Updated',
        'An error occurred! Please correct the errors and try again.'
    );
    const columns: IListingColumn[] = [
        {
            align: 'center',
            label: 'Category',
            dataKey: 'title',
            colspan: 20,
            retrieveAllData: true,
            component: (data, refresh) => (
                <EditColumn
                    name='ingredientCategoryId'
                    edit={(data as IData).ingredientCategoryId == editId}
                    data={data as IData}
                    submitting={submitting}
                    submitCallback={async (newValue) => {
                        const { ingredientCategoryId } = data as IData;
                        await edit(ingredientCategoryId as number, newValue);
                        refresh?.();
                        refresher?.();
                    }}
                />
            ),
        },
    ];

    const headerButtons: IActionButton[] = [
        {
            color: 'green',
            tooltip: 'Add Category',
            icon: <CategoriesIcon />,
            action: () => {
                setAddRow(true);
            },
        },
    ];

    const rowButtons: IActionButton[] = [
        {
            color: 'blue',
            tooltip: 'Edit Category',
            argKey: 'ingredientCategoryId',
            icon: <QuillIcon />,
            noRefresh: true,
            action: (id) => {
                if (editId !== id) setEditId(id as number);
            },
        },
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

    const add = async (title: string) => {
        const post = {
            title: title,
        };

        await submitForm(post, () => {
            setAddRow(false);
            refresher?.();
            setDraw(draw + 1);
        });
    };

    const edit = async (id: number, title: string) => {
        const put = {
            editId,
            ingredientCategoryId: id,
            title: title,
        };

        await submitForm(put, () => {
            setEditId(undefined);
            refresher?.();
            setDraw(draw + 1);
        });
    };

    const remove = async (id: number) => {
        const post = {
            ingredientCategoryId: id,
        };

        const response = await axios.post(`ingredientcategory/remove/`, post, user?.authConfig);
        if (response.data.error) {
            const message = response.data.errors.error;
            toaster.push(
                <Message type='error'>
                    <>{message}</>
                </Message>,
                { duration: 5000 }
            );
        } else {
            toaster.push(<Message type='success'>Removed Category</Message>, { duration: 5000 });
            refresher?.();
            setDraw(draw + 1);
        }
    };

    return (
        <>
            <Listing
                id='ingredientCategoryId'
                columns={columns}
                route={'ingredientcategory'}
                headerButtons={headerButtons}
                rowButtons={rowButtons}
                refresher={draw}
                ignoreCheckbox
                ignorePagination
            />
            {addRow && <AddRow columns={columns} rowButtons={rowButtons} onSubmit={add} ignoreCheckbox />}
        </>
    );
};

export default IngredientCategoryListing;
