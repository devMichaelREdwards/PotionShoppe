import { useEffect, useState } from 'react';
import ActionButton from '../../common/input/ActionButton';
import { Form } from 'rsuite';
import { ImageSelectorControl, NumberControl, StringSearchInput, TextAreaControl, TextControl } from '../../common/input/FormControl';
import { useID } from '../../../hooks/useData';
import { useSubmit } from '../../../hooks/useSubmit';
import { ICollectionObject } from '../../../types/IListing';
import { API_URL } from '../../../api/api';
import { IPostData } from '../../../types/IData';

interface IProps {
    editId?: number;
    toggleEdit: (active: boolean) => void;
}

const IngredientForm = ({ editId, toggleEdit }: IProps) => {
    const { data, loading } = useID(editId ? `ingredient/${editId}` : '');
    const [image, setImage] = useState(`${API_URL}/image/`);
    const [name, setName] = useState('');
    const [categoryId, setCategoryId] = useState(0);
    const [categoryQuery, setCategoryQuery] = useState('');
    const [description, setDescription] = useState('');
    const [effectId, setEffectId] = useState(0);
    const [effectQuery, setEffectQuery] = useState('');
    const [cost, setCost] = useState('0');
    const [price, setPrice] = useState('0');
    const [currentStock, setCurrentStock] = useState('0');

    const { submitting, errors, submitForm } = useSubmit(
        'ingredient',
        'Ingredient Saved',
        'An error occurred! Please correct the errors and try again.'
    );

    useEffect(() => {
        const ingredient = data;
        if (!editId || !ingredient) return;
        setName(ingredient.name as string);
        setImage(ingredient.image as string);
        setCategoryId(ingredient.ingredientCategoryId as number);
        setCategoryQuery(ingredient.ingredientCategory as string);
        setDescription(ingredient.description as string);
        setEffectId(ingredient.effectId as number);
        setEffectQuery((ingredient.effect as IPostData).title as string);
        setCost(ingredient.cost as string);
        setPrice(ingredient.price as string);
        setCurrentStock(ingredient.currentStock as string);
    }, [data]);

    const handleSubmit = async () => {
        const data = {
            editId: editId,
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
            <Form.Group>
                <ImageSelectorControl
                    value={image}
                    api={`${API_URL}/image`}
                    label='Image'
                    onImageChange={(img: string) => {
                        setImage(img);
                    }}
                />
            </Form.Group>

            <ActionButton
                appearance='ghost'
                label='Back to list'
                color='purple'
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
