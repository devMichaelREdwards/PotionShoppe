import { useState } from 'react';
import { Form, Button } from 'rsuite';
import { IData } from '../../../../types/IData';
import { TextControl } from '../../input/FormControl';

interface IProps {
    edit: boolean;
    data: IData;
    name: string;
    submitting: boolean;
    submitCallback: (value: string) => Promise<void>;
}

const EditColumn = ({ edit, data, name, submitting, submitCallback }: IProps) => {
    const { title } = data;
    const [editValue, setEditValue] = useState(title as string);
    if (edit && submitting) return <>Submitting...</>;
    if (edit)
        return (
            <Form
                fluid
                onSubmit={async (check, event) => {
                    event.preventDefault();
                    await submitCallback(editValue);
                }}
            >
                <TextControl value={editValue} name={name} onChange={(e) => setEditValue(e)} />
                <Button className='hidden' />
            </Form>
        );
    return <>{title}</>;
};

export default EditColumn;
