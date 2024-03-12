import { useState } from 'react';
import { Form, InputGroup, InputNumber, RangeSlider } from 'rsuite';

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
    id: string;
    onRangeChange: (value: [number, number]) => void;
}

export const RangeSliderControl = ({ label, min, max, id, onRangeChange }: IRangeSlider) => {
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
            <InputGroup>
                <InputNumber
                    id={`${id}-min`}
                    value={value[0]}
                    onChange={(nextValue) => {
                        const next = nextValue as number;
                        if (next > value[1]) {
                            return;
                        }
                        setValue([next, value[1]]);
                        onRangeChange([next, value[1]]);
                    }}
                />
                <InputGroup.Addon>to</InputGroup.Addon>
                <InputNumber
                    id={`${id}-max`}
                    value={value[1]}
                    onChange={(nextValue) => {
                        const next = nextValue as number;
                        if (value[0] > next) {
                            return;
                        }
                        setValue([value[0], next]);
                        onRangeChange([value[0], next]);
                    }}
                />
            </InputGroup>
        </span>
    );
};
