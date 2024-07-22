import { useEffect, useState } from 'react';
import ActionButton from '../../common/input/ActionButton';
import { Form } from 'rsuite';
import { ColorPickerControl, NumberControl, TextAreaControl, TextControl } from '../../common/input/FormControl';
import { useID } from '../../../hooks/useData';
import { useSubmit } from '../../../hooks/useSubmit';

interface IProps {
    editId?: number;
    toggleEdit: (active: boolean) => void;
}

const EffectForm = ({ editId, toggleEdit }: IProps) => {
    const { data, loading } = useID(editId ? `effect/${editId}` : '');
    const [name, setName] = useState('');
    const [value, setValue] = useState('0');
    const [duration, setDuration] = useState('0');
    const [description, setDescription] = useState('');
    const [color, setColor] = useState('#ff0000');
    const { submitting, errors, submitForm } = useSubmit('effect', 'Effect Saved', 'An error occurred! Please correct the errors and try again.');

    useEffect(() => {
        const effect = data;
        if (!editId || !effect) return;
        setName(effect.name as string);
        setValue(effect.value as string);
        setDuration(effect.duration as string);
        setDescription(effect.description as string);
        setColor(effect.color as string);
    }, [data]);

    const handleSubmit = async () => {
        const data = {
            editId: editId,
            effectId: editId,
            name,
            value,
            duration,
            description,
            color,
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
                    value={value}
                    label='Value'
                    name='value'
                    onChange={(e: number) => {
                        if (e < 0) {
                            setValue('0');
                            return;
                        }
                        setValue(e.toString());
                    }}
                />
            </Form.Group>
            <Form.Group>
                <NumberControl
                    value={duration}
                    label='Duration'
                    name='duration'
                    onChange={(e: number) => {
                        if (e < 0) {
                            setDuration('0');
                            return;
                        }
                        setDuration(e.toString());
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
                <ColorPickerControl
                    value={color}
                    label='Color'
                    name='color'
                    onChange={(e: string) => {
                        setColor(e);
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

export default EffectForm;
