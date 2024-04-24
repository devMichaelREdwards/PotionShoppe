import { useEffect, useState } from 'react';
import ActionButton from '../../common/input/ActionButton';
import { Form, Message, useToaster } from 'rsuite';
import { ColorPickerControl, NumberControl, TextAreaControl, TextControl } from '../../common/input/FormControl';
import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';

interface IProps {
    editId: number;
    toggleEdit: (active: boolean) => void;
}

const EffectForm = ({ editId, toggleEdit }: IProps) => {
    const [name, setName] = useState('');
    const [value, setValue] = useState('');
    const [duration, setDuration] = useState('');
    const [description, setDescription] = useState('');
    const [color, setColor] = useState('#ff0000');
    const toaster = useToaster();
    const { user } = useAuth();
    useEffect(() => {
        //console.log(editId);
        // Populate edit form here
    });
    const handleSubmit = async () => {
        if (editId > 0) {
            const data = {
                effectId: editId,
                name,
                value,
                duration,
                description,
                color,
            };
            await axios
                .put('effect', data, user?.authConfig)
                .then(() => {
                    // Put successful
                    toaster.push(<Message type='success'>Effect Saved</Message>, { duration: 5000 });
                })
                .catch((error) => {
                    // Put failed
                    toaster.push(<Message type='error'>{error.response.data}</Message>, { duration: 5000 });
                });
        } else {
            const data = {
                name,
                value,
                duration,
                description,
                color,
            };

            await axios
                .post('effect', data, user?.authConfig)
                .then((res) => {
                    // Post successful
                    toaster.push(<Message type='success'>Effect Saved</Message>, { duration: 5000 });
                })
                .catch((error) => {
                    // Post failed
                    toaster.push(<Message type='error'>An error occurred! Please check the form and try again.</Message>, { duration: 5000 });
                });
        }
    };
    return (
        <Form fluid>
            <Form.Group>
                <TextControl
                    value={name}
                    label='Name'
                    name='name'
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
                            setValue('');
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
                            setDuration('');
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
