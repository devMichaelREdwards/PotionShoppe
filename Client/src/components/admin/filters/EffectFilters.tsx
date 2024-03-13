import { useState } from 'react';
import { Form } from 'rsuite';
import { IEffectFilters } from '../../../types/IFilter';
import { TextControl, RangeSliderControl } from '../../common/input/FormControl';
import { MagicWandIcon } from '../../common/image/Icon';
import { debounce } from '../../../helpers/timing';
import ActionButton from '../../common/input/ActionButton';

interface IEffectFiltersProps {
    filters: IEffectFilters;
    filterLimits: IEffectFilters;
    setFilters: React.Dispatch<React.SetStateAction<IEffectFilters>>;
    onClearCallback?: () => void;
}

const EffectFilters = ({ filters, filterLimits, setFilters, onClearCallback }: IEffectFiltersProps) => {
    const [name, setName] = useState('');
    const [value, setValue] = useState<[number, number]>([filterLimits.vmin ?? 0, filterLimits.vmax ?? 1000]);
    const [duration, setDuration] = useState<[number, number]>([filterLimits.dmin ?? 0, filterLimits.dmax ?? 1000]);

    const setFilterByKey = (key: keyof IEffectFilters, value: string | number) => {
        setFilters({ ...filters, [key]: value });
    };

    const setValueRange = debounce((range: [number, number]) => {
        setFilters({ ...filters, vmin: range[0], vmax: range[1] });
    }, 500);

    const setDurationRange = debounce((range: [number, number]) => {
        setFilters({ ...filters, dmin: range[0], dmax: range[1] });
    }, 500);
    const clearFilters = () => {
        setFilters({
            name: '',
            vmin: filterLimits.vmin ?? 0,
            vmax: filterLimits.vmax ?? 1000,
            dmin: filterLimits.dmin ?? 0,
            dmax: filterLimits.dmax ?? 1000,
        });
        onClearCallback?.();
    };
    const clearFiltersClick = () => {
        setName('');
        setValue([filterLimits.vmin ?? 0, filterLimits.vmax ?? 1000]);
        setDuration([filterLimits.dmin ?? 0, filterLimits.dmax ?? 1000]);
        clearFilters();
    };
    return (
        <div className='filters'>
            <div className='filter-icon'>
                <MagicWandIcon />
                Filters
            </div>
            <Form className='filter-form'>
                <Form.Group className='filter-group'>
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
                        value={value}
                        id={'value'}
                        label={'Value'}
                        min={filterLimits.vmin ?? 0}
                        max={filterLimits.vmax ?? 1000}
                        onRangeChange={(e) => {
                            setValue(e);
                            setValueRange(e);
                        }}
                    />
                    <RangeSliderControl
                        value={duration}
                        id={'duration'}
                        label={'Duration'}
                        min={filterLimits.dmin ?? 0}
                        max={filterLimits.dmax ?? 1000}
                        onRangeChange={(e) => {
                            setDuration(e);
                            setDurationRange(e);
                        }}
                    />
                </Form.Group>
            </Form>
            <div className='clear-filters-button'>
                <ActionButton color={'red'} appearance={'ghost'} label={'Clear Filters'} action={clearFiltersClick} />
            </div>
        </div>
    );
};

export default EffectFilters;
