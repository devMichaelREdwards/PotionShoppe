import { useEffect, useState } from 'react';
import { Form, Message, useToaster } from 'rsuite';
import { useID } from '../../../hooks/useData';
import { useSubmit } from '../../../hooks/useSubmit';
import { API_URL } from '../../../api/axios';
import { IData, IPostData } from '../../../types/IData';
import { CollectionSearchInput, ImageSelectorControl, NumberControl, TextAreaControl, TextControl } from '../../common/input/FormControl';
import { ICollectionObject } from '../../../types/IListing';
import ActionButton from '../../common/input/ActionButton';

interface IProps {
    editId?: number;
    toggleEdit: (active: boolean) => void;
}

const PotionForm = ({ editId, toggleEdit }: IProps) => {
    const toaster = useToaster();
    const { data, loading } = useID(editId ? `potion/${editId}` : '');
    const [image, setImage] = useState(`${API_URL}/image/`);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [cost, setCost] = useState('0');
    const [price, setPrice] = useState('0');
    const [currentStock, setCurrentStock] = useState('0');
    const [effectQuery, setEffectQuery] = useState('');
    const [effects, setEffects] = useState<ICollectionObject[]>([]);
    const { submitting, errors, submitForm } = useSubmit('potion', 'Potion Saved', 'An error occurred! Please correct the errors and try again.');

    const addEffect = (effect: ICollectionObject) => {
        if (effects.length >= 5) {
            toaster.push(<Message type='error'>A potion can only have 5 effects.</Message>, { duration: 5000 });
            return;
        }

        const newEffects = [...effects, effect];
        setEffects(newEffects);
    };

    const removeEffect = (index: number) => {
        const newEffects = [...effects.filter((e, i) => i !== index)];
        setEffects(newEffects);
    };

    const buildEffectData = () => {
        const result: IPostData[] = [];
        effects.forEach((e) => {
            result.push({
                potionId: editId,
                effectId: e.id,
            });
        });
        return result;
    };

    useEffect(() => {
        const potion = data;
        if (!editId || !potion) return;
        setName(potion.name as string);
        setImage(potion.image as string);
        setDescription(potion.description as string);
        setCost(potion.cost as string);
        setPrice(potion.price as string);
        setCurrentStock(potion.currentStock as string);

        const loadedEffects = (potion.potionEffects as IData[]).map((e) => {
            return { ...e, id: e.effectId } as ICollectionObject;
        });

        setEffects(loadedEffects);
    }, [data]);

    const handleSubmit = async () => {
        const data = {
            editId: editId,
            potionId: editId,
            name,
            description,
            price,
            cost,
            currentStock,
            image,
            potionEffects: buildEffectData(),
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
            <Form.Group>
                <CollectionSearchInput
                    value={effectQuery}
                    label='Effect'
                    route='effect/listing'
                    tags={effects}
                    idKey='effectId'
                    dataKey='name'
                    addTag={addEffect}
                    removeTag={removeEffect}
                    setValue={(newValue) => setEffectQuery(newValue)}
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

export default PotionForm;
