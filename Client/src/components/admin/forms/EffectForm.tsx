import { useEffect, useState } from 'react';
import ActionButton from '../../common/input/ActionButton';
import { Form } from 'rsuite';
import { NumberControl, TextAreaControl, TextControl } from '../../common/input/FormControl';

interface IProps {
    editId: number;
    toggleEdit: (active: boolean) => void;
}

const EffectForm = ({ editId, toggleEdit }: IProps) => {
    const [name, setName] = useState('');
    const [value, setValue] = useState('');
    const [duration, setDuration] = useState('');
    const [description, setDescription] = useState('');
    useEffect(() => {
        //console.log(editId);
    });
    const handleSubmit = () => {};
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
            <ActionButton
                appearance='ghost'
                label='Back to list'
                color='violet'
                action={() => {
                    toggleEdit(false);
                }}
            />
        </Form>
    );
};

export default EffectForm;
