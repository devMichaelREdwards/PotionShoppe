import { useEffect, useState } from 'react';
import { AutoComplete, Checkbox, Form, InputGroup, InputNumber, RangeSlider } from 'rsuite';
import { useData } from '../../../hooks/useData';
import { IData } from '../../../types/IData';
import { ICollectionObject } from '../../../types/IListing';
import Color from 'color';

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

interface ICheckbox {
    value: boolean;
    label?: string;
    name: string;
    onChange: () => void;
}

export const CheckboxControl = ({ value, label, name, onChange }: ICheckbox) => {
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <Checkbox
                className='checkbox'
                id={`instock-filter`}
                value={name}
                checked={value}
                onChange={() => {
                    onChange();
                }}
            />
        </span>
    );
};

interface IRangeSlider {
    value: [number, number];
    label: string;
    min: number;
    max: number;
    id: string;
    onRangeChange: (value: [number, number]) => void;
}

export const RangeSliderControl = ({ value, label, min, max, id, onRangeChange }: IRangeSlider) => {
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
                    onRangeChange(value);
                }}
            />
            <InputGroup>
                <InputNumber
                    className='form-control-input'
                    id={`${id}-min`}
                    value={value[0]}
                    onChange={(nextValue) => {
                        const next = nextValue as number;
                        if (next > value[1]) {
                            return;
                        }
                        onRangeChange([next, value[1]]);
                    }}
                />
                <InputGroup.Addon>to</InputGroup.Addon>
                <InputNumber
                    className='form-control-input'
                    id={`${id}-max`}
                    value={value[1]}
                    onChange={(nextValue) => {
                        const next = nextValue as number;
                        if (value[0] > next) {
                            return;
                        }
                        onRangeChange([value[0], next]);
                    }}
                />
            </InputGroup>
        </span>
    );
};

interface IStringSearchInput {
    value: string;
    label?: string;
    placeholder?: string;
    route: string;
    idKey: string;
    dataKey: string;
    onSelect: (data: ICollectionObject) => void;
    setValue: (value: string) => void;
}

export const StringSearchInput = ({ value, label, placeholder, route, idKey, dataKey, onSelect, setValue }: IStringSearchInput) => {
    const { data } = useData(route);
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <AutoComplete
                className='form-control-input'
                placeholder={placeholder}
                value={value}
                data={data.map((item) => {
                    return item[dataKey] as string;
                })}
                name={dataKey}
                onChange={(e) => setValue(e)}
                onSelect={(v: IData) => {
                    const selected = data.find((d) => {
                        return d[dataKey] == v;
                    });
                    if (!selected) return;
                    const collectionObj = {
                        id: selected[idKey] as number,
                        title: selected[dataKey] as string,
                        color: selected['color'] as string,
                    };
                    selected && onSelect(collectionObj);
                }}
            />
        </span>
    );
};

interface ITagSearchInput {
    value: string;
    label?: string;
    placeholder?: string;
    tags: ICollectionObject[];
    route: string;
    idKey: string;
    dataKey: string;
    addTag: (tags: ICollectionObject) => void;
    setValue: (value: string) => void;
    removeTag: (id: number) => void;
}

export const TagSearchInput = ({ value, label, placeholder, tags, route, idKey, dataKey, addTag, removeTag, setValue }: ITagSearchInput) => {
    const [dirty, setDirty] = useState(false);
    const { data } = useData(route);

    useEffect(() => {
        // This is the only way that the input clears after onSelect due to onChange being called after onSelect
        // Maybe just rewrite this component? Rsuite failed me here
        if (dirty) {
            setValue('');
            setDirty(false);
        }
    }, [dirty, setValue]);

    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <AutoComplete
                className='form-control-input'
                placeholder={placeholder}
                data={data.map((item) => {
                    return item[dataKey] as string;
                })}
                name={dataKey}
                value={value}
                onChange={(e) => {
                    setValue(e);
                }}
                onSelect={(v: IData) => {
                    const selected = data.find((d) => {
                        return d[dataKey] == v;
                    });
                    if (!selected) return;
                    const color = (selected['color'] as { color: string })['color'] as string;
                    const collectionObj = {
                        id: selected[idKey] as number,
                        title: selected[dataKey] as string,
                        color: color,
                    };
                    addTag(collectionObj);
                    setDirty(true);
                }}
            />
            <div className='form-control-tags'>
                {tags.map((tag) => {
                    const colorString: string = tag.color ? tag.color : 'grey';
                    try {
                        const colorData = Color(colorString);
                        return (
                            <div className={`tag ${colorData.isLight() ? 'light' : 'dark'}`} style={{ backgroundColor: `${colorString}` }}>
                                {tag.title}
                            </div>
                        );
                    } catch (e) {
                        // If the color string cannot be parsed
                        return (
                            <div className={`tag light`} style={{ backgroundColor: `${'grey'}` }}>
                                {tag.title}
                            </div>
                        );
                    }
                })}
            </div>
        </span>
    );
};
