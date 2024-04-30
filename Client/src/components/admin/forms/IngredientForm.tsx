import { useEffect, useState } from 'react';
import ActionButton from '../../common/input/ActionButton';
import { Form } from 'rsuite';
import { NumberControl, StringSearchInput, TextAreaControl, TextControl } from '../../common/input/FormControl';
import { useID } from '../../../hooks/useData';
import { useSubmit } from '../../../hooks/useSubmit';
import { ICollectionObject } from '../../../types/IListing';

interface IProps {
    editId?: number;
    toggleEdit: (active: boolean) => void;
}

const IngredientForm = ({ editId, toggleEdit }: IProps) => {
    const { data, loading } = useID(editId ? `effect/${editId}` : '');
    const [image, setImage] = useState(''); // Image picker needed
    const [name, setName] = useState('');
    const [categoryId, setCategoryId] = useState(0); // Use search input
    const [categoryQuery, setCategoryQuery] = useState('');
    const [description, setDescription] = useState('');
    const [effectId, setEffectId] = useState(0); // Use search input
    const [effectQuery, setEffectQuery] = useState(''); // Use search input
    const [cost, setCost] = useState('0');
    const [price, setPrice] = useState('0');
    const [currentStock, setCurrentStock] = useState('0');

    const { submitting, errors, submitForm } = useSubmit(
        'ingredient',
        'Ingredient Saved',
        'An error occurred! Please correct the errors and try again.'
    );

    useEffect(() => {
        const effect = data;
        if (!editId || !effect) return;
        setName(effect.name as string);
    }, [data]);

    const handleSubmit = async () => {
        const data = {
            ingredientId: editId,
            name,
            description,
            price,
            cost,
            currentStock,
            image,
            effectId: effectId,
            ingredientCategoryId: categoryId,
        };

        submitForm(data, () => toggleEdit(false));
    };

    if (loading || submitting) return <>Loading Screen...</>;
    return (
        <Form fluid>
            <Form.Group>
                <TextControl
                    value={name}
                    label='Name'
                    name='name'
                    error={errors?.name}
                    onChange={(e: string) => {
                        setName(e);
                    }}
                />
            </Form.Group>
            <Form.Group>
                <StringSearchInput
                    value={categoryQuery}
                    label='Category'
                    route='ingredientcategory'
                    idKey='ingredientCategoryId'
                    dataKey='title'
                    error={errors?.category}
                    onSelect={(e: ICollectionObject) => {
                        setCategoryId(e.id ?? 0);
                        setCategoryQuery(e.title);
                    }}
                    setValue={(v) => setCategoryQuery(v)}
                />
            </Form.Group>
            <Form.Group>
                <StringSearchInput
                    value={effectQuery}
                    label='Effect'
                    route='effect/listing'
                    idKey='effectId'
                    dataKey='name'
                    error={errors?.category}
                    onSelect={(e: ICollectionObject) => {
                        setEffectId(e.id ?? 0);
                        setEffectQuery(e.title);
                    }}
                    setValue={(v) => setEffectQuery(v)}
                />
            </Form.Group>
            <Form.Group>
                <NumberControl
                    value={cost}
                    label='Cost'
                    name='cost'
                    onChange={(e: number) => {
                        if (e < 0) {
                            setCost('0');
                            return;
                        }
                        setCost(e.toString());
                    }}
                />
            </Form.Group>
            <Form.Group>
                <NumberControl
                    value={price}
                    label='Price'
                    name='price'
                    onChange={(e: number) => {
                        if (e < 0) {
                            setPrice('0');
                            return;
                        }
                        setPrice(e.toString());
                    }}
                />
            </Form.Group>
            <Form.Group>
                <NumberControl
                    value={currentStock}
                    label='In Stock'
                    name='currentStock'
                    onChange={(e: number) => {
                        if (e < 0) {
                            setCurrentStock('0');
                            return;
                        }
                        setCurrentStock(e.toString());
                    }}
                />
            </Form.Group>
            <Form.Group>
                <TextAreaControl
                    value={description}
                    label='Description'
                    name='description'
                    onChange={(e: string) => {
                        setDescription(e);
                    }}
                />
            </Form.Group>

            <ActionButton
                appearance='ghost'
                label='Back to list'
                color='violet'
                action={() => {
                    toggleEdit(false);
                }}
            />
            <ActionButton
                appearance='ghost'
                label='Submit'
                color='green'
                action={() => {
                    handleSubmit();
                }}
            />
        </Form>
    );
};

export default IngredientForm;
