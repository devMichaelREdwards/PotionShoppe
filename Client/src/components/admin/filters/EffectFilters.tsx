import { useState } from 'react';
import { Button, Form } from 'rsuite';
import { IEffectFilters } from '../../../types/IFilter';
import { TextControl, RangeSliderControl } from '../../common/input/FormControl';

interface IEffectFiltersProps {
    filterLimits: IEffectFilters;
    setFilterByKey: (key: keyof IEffectFilters, value: string | number) => void;
    setValueRange: (range: [number, number]) => void;
    setDurationRange: (range: [number, number]) => void;
    clearFilters: () => void;
}

const EffectFilters = ({ filterLimits, setFilterByKey, setValueRange, setDurationRange, clearFilters }: IEffectFiltersProps) => {
    const [name, setName] = useState('');
    const clearFiltersClick = () => {
        setName('');
        clearFilters();
    };
    return (
        <Form className='filters'>
            <Form.Group>
                <TextControl
                    value={name}
                    label='Name'
                    name='name'
                    onChange={(e: string) => {
                        setName(e);
                        setFilterByKey('name', e);
                    }}
                />
                <RangeSliderControl
                    id={'value'}
                    label={'Value'}
                    min={filterLimits.vmin ?? 0}
                    max={filterLimits.vmax ?? 1000}
                    onRangeChange={(e) => {
                        setValueRange(e);
                    }}
                />
                <RangeSliderControl
                    id={'duration'}
                    label={'Duration'}
                    min={filterLimits.dmin ?? 0}
                    max={filterLimits.dmax ?? 1000}
                    onRangeChange={(e) => {
                        setDurationRange(e);
                    }}
                />
            </Form.Group>

            <Button onClick={clearFiltersClick}>Clear Filters</Button>
        </Form>
    );
};

export default EffectFilters;
