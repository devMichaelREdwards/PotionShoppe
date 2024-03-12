import { useState } from 'react';
import { Form, RangeSlider } from 'rsuite';

interface IInput {
    value: string | number | readonly string[] | undefined;
    placeholder?: string;
    label?: string;
    name: string;
    onChange: (value: string) => void;
}

export const TextControl = ({ value, label, placeholder, name, onChange }: IInput) => {
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <Form.Control
                className='form-control-input'
                value={value}
                placeholder={placeholder}
                name={name}
                onChange={(e: string) => {
                    onChange(e);
                }}
            />
        </span>
    );
};

export const PasswordControl = ({ value, label, placeholder, name, onChange }: IInput) => {
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <Form.Control
                className='form-control-input'
                value={value}
                placeholder={placeholder}
                name={name}
                type='password'
                onChange={(e: string) => {
                    onChange(e);
                }}
            />
        </span>
    );
};

interface IRangeSlider {
    label: string;
    min: number;
    max: number;
    onRangeChange: (value: [number, number]) => void;
}

export const RangeSliderControl = ({ label, min, max, onRangeChange }: IRangeSlider) => {
    const [value, setValue] = useState([min, max]);
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <RangeSlider
                className='form-control-input'
                progress
                value={[value[0], value[1]]}
                min={min}
                max={max}
                onChange={(value) => {
                    setValue(value);
                    onRangeChange(value);
                }}
            />
        </span>
    );
};
