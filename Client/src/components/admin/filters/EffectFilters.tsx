import { useState } from 'react';
import { Form } from 'rsuite';
import { IEffectFilters } from '../../../types/IFilter';
import { TextControl, RangeSliderControl } from '../../common/input/FormControl';
import { debounce } from '../../../helpers/timing';
import FilterTitle from './FilterTitle';
import ClearFilterButton from './ClearFilterButton';

interface IProps {
    filters: IEffectFilters;
    filterLimits: IEffectFilters;
    setFilters: React.Dispatch<React.SetStateAction<IEffectFilters>>;
    onClearCallback?: () => void;
}

const EffectFilters = ({ filters, filterLimits, setFilters, onClearCallback }: IProps) => {
    const [name, setName] = useState(filters.name ?? '');
    const [value, setValue] = useState<[number, number]>([filters.vmin ?? filterLimits.vmin ?? 0, filters.vmax ?? filterLimits.vmax ?? 1000]);
    const [duration, setDuration] = useState<[number, number]>([filters.dmin ?? filterLimits.dmin ?? 0, filters.dmax ?? filterLimits.dmax ?? 1000]);

    const setFilterByKey = (key: keyof IEffectFilters, value: string | number) => {
        setFilters({ ...filters, [key]: value });
        onClearCallback?.();
    };

    const setValueRange = debounce((range: [number, number]) => {
        setFilters({ ...filters, vmin: range[0], vmax: range[1] });
        onClearCallback?.();
    }, 500);

    const setDurationRange = debounce((range: [number, number]) => {
        setFilters({ ...filters, dmin: range[0], dmax: range[1] });
        onClearCallback?.();
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
            <FilterTitle />
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
            <ClearFilterButton clearFiltersClick={clearFiltersClick} />
        </div>
    );
};

export default EffectFilters;
