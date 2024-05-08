import { useEffect, useState } from 'react';
import { AutoComplete, Button, Checkbox, Form, InputGroup, InputNumber, Modal, RangeSlider } from 'rsuite';
import { useData } from '../../../hooks/useData';
import { IData } from '../../../types/IData';
import { ICollectionObject } from '../../../types/IListing';
import Color from 'color';
import CloseIcon from '@rsuite/icons/Close';
import { SliderPicker } from 'react-color';
import ImageButton from './ImageButton';
import ImageSelectorModal from '../../admin/modal/ImageSelectorModal';

interface IInput {
    value: string | number | readonly string[] | undefined;
    placeholder?: string;
    label?: string;
    name: string;
    error?: string;
    onChange: (value: string) => void;
}

export const TextControl = ({ value, label, placeholder, name, error, onChange }: IInput) => {
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <Form.Control
                className='form-control-input'
                value={value}
                placeholder={placeholder}
                name={name}
                errorMessage={error}
                onChange={(e: string) => {
                    onChange(e);
                }}
            />
        </span>
    );
};

export const TextAreaControl = ({ value, label, placeholder, name, onChange }: IInput) => {
    return (
        <span className='form-control text-area'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <textarea
                className='form-control-input textarea-input'
                value={value}
                name={name}
                placeholder={placeholder}
                onChange={(e) => {
                    onChange(e.target.value);
                }}
            >
                {' '}
            </textarea>
        </span>
    );
};

export const ColorPickerControl = ({ value, label, placeholder, name, onChange }: IInput) => {
    try {
        const colorData = Color(value);
        const pickerStyles = { backgroundColor: colorData.hex() };
        return (
            <span className='form-control color-picker'>
                <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
                <span className='color-picker-input'>
                    <span className='color-display'>
                        <span className='color-display-outline'>
                            <span className='color-display-inner' style={pickerStyles}></span>
                        </span>
                    </span>
                    <span className='color-picker-slider'>
                        <SliderPicker
                            color={colorData.hex()}
                            onChange={(color) => {
                                onChange?.(color.hex);
                            }}
                        />
                    </span>
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
            </span>
        );
    } catch {
        const colorData = Color('#fff');
        const pickerStyles = { backgroundColor: colorData.hex() };
        return (
            <span className='form-control color-picker'>
                <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
                <span className='color-picker-input'>
                    <span className='color-display'>
                        <span className='color-display-outline'>
                            <span className='color-display-inner' style={pickerStyles}></span>
                        </span>
                    </span>
                    <span className='color-picker-slider'>
                        <SliderPicker
                            color={colorData.hex()}
                            onChange={(color) => {
                                onChange?.(color.hex);
                            }}
                        />
                    </span>
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
            </span>
        );
    }
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

interface INumberInput {
    value: string | number | readonly string[] | undefined;
    placeholder?: string;
    label?: string;
    name: string;
    onChange: (value: number) => void;
}

export const NumberControl = ({ value, label, placeholder, name, onChange }: INumberInput) => {
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <InputNumber
                className='form-control-input'
                value={value as number}
                placeholder={placeholder}
                name={name}
                onChange={(e: string | number) => {
                    onChange(+e);
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
        <span className='form-control checkbox-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <Checkbox
                className='checkbox'
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

interface IImageSelectorControl {
    value: string;
    api: string;
    label: string;
    onImageChange: (value: string) => void;
}

export const ImageSelectorControl = ({ value, api, label, onImageChange }: IImageSelectorControl) => {
    const [open, setOpen] = useState(false);

    const openModal = () => {
        setOpen(true);
    };

    const closeModal = () => {
        setOpen(false);
    };

    const selectImage = (src: string) => {
        onImageChange(src);
        setOpen(false);
    };
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <span className='image-selector-input'>
                <ImageButton src={`${value}`} onClick={openModal} />
            </span>
            <ImageSelectorModal open={open} api={api} closeModal={closeModal} selectImage={selectImage} />
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
    error?: string;
    onSelect: (data: ICollectionObject) => void;
    setValue: (value: string) => void;
}

export const StringSearchInput = ({ value, label, placeholder, route, idKey, dataKey, onSelect, setValue }: IStringSearchInput) => {
    const { data } = useData(route);
    return (
        <span className='form-control'>
            <Form.ControlLabel className='form-control-label'>{label}</Form.ControlLabel>
            <AutoComplete
                className='form-control-input autocomplete-input'
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
                menuClassName='autocomplete-popup'
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
                    const color = selected['color'] ? ((selected['color'] as { color: string })['color'] as string) : 'grey';
                    const collectionObj = {
                        id: selected[idKey] as number,
                        title: selected[dataKey] as string,
                        color: color,
                    };
                    addTag(collectionObj);
                    setDirty(true);
                }}
            />
            {tags.length > 0 && (
                <div className='form-control-tags'>
                    {tags.map((tag) => {
                        const colorString: string = tag.color ? tag.color : 'grey';
                        try {
                            const colorData = Color(colorString);
                            return (
                                <div className={`tag ${colorData.isLight() ? 'light' : 'dark'}`} style={{ backgroundColor: `${colorString}` }}>
                                    <span className='tag-space'></span>
                                    <span className='tag-title'>{tag.title}</span>
                                    <span className='tag-close'>
                                        <Button
                                            appearance='subtle'
                                            onClick={() => {
                                                removeTag(tag.id ?? 0);
                                            }}
                                        >
                                            <CloseIcon />
                                        </Button>
                                    </span>
                                </div>
                            );
                        } catch (e) {
                            // If the color string cannot be parsed
                            return (
                                <div className={`tag light`} style={{ backgroundColor: 'grey' }}>
                                    <span className='tag-space'></span>
                                    <span className='tag-title'>{tag.title}</span>
                                    <span className='tag-close'>
                                        <Button
                                            appearance='subtle'
                                            onClick={() => {
                                                removeTag(tag.id ?? 0);
                                            }}
                                        >
                                            <CloseIcon />
                                        </Button>
                                    </span>
                                </div>
                            );
                        }
                    })}
                </div>
            )}
        </span>
    );
};
