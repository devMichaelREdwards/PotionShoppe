import { useState } from 'react';
import { IPotionFilters } from '../../../types/IFilter';
import { debounce } from '../../../helpers/timing';
import { Form } from 'rsuite';
import { TextControl, RangeSliderControl, CheckboxControl, TagSearchInput } from '../../common/input/FormControl';
import { ICollectionObject } from '../../../types/IListing';
import ClearFilterButton from './ClearFilterButton';
import FilterTitle from './FilterTitle';

interface IProps {
    filters: IPotionFilters;
    filterLimits: IPotionFilters;
    setFilters: React.Dispatch<React.SetStateAction<IPotionFilters>>;
    onClearCallback?: () => void;
}

const PotionFilters = ({ filters, filterLimits, setFilters, onClearCallback }: IProps) => {
    const [name, setName] = useState('');
    const [effectQuery, setEffectQuery] = useState('');
    const [effects, setEffects] = useState<ICollectionObject[]>([]);
    const [cost, setCost] = useState<[number, number]>([filterLimits.cmin ?? 0, filterLimits.cmax ?? 1000]);
    const [price, setPrice] = useState<[number, number]>([filterLimits.pmin ?? 0, filterLimits.pmax ?? 1000]);
    const [inStock, setInStock] = useState(filterLimits.instock ?? false);

    const setFilterByKey = (key: keyof IPotionFilters, value: string | number | boolean) => {
        setFilters({ ...filters, [key]: value });
        onClearCallback?.();
    };

    const setCostRange = debounce((range: [number, number]) => {
        setFilters({ ...filters, cmin: range[0], cmax: range[1] });
    });

    const setPriceRange = debounce((range: [number, number]) => {
        setFilters({ ...filters, pmin: range[0], pmax: range[1] });
    });

    const addEffect = (effect: ICollectionObject) => {
        const newEffects = [...effects, effect];
        setEffects(newEffects);
        setFilters({ ...filters, effects: newEffects.map((e) => e.id ?? 0) });
        onClearCallback?.();
    };

    const removeEffect = (id: number) => {
        const newEffects = [...effects.filter((e) => e.id !== id)];
        setEffects(newEffects);
        setFilters({ ...filters, effects: newEffects.map((e) => e.id ?? 0) });
        onClearCallback?.();
    };

    const clearFilters = () => {
        setFilters({
            name: '',
            effects: [],
            cmin: filterLimits.cmin ?? 0,
            cmax: filterLimits.cmax ?? 1000,
            pmin: filterLimits.pmin ?? 0,
            pmax: filterLimits.pmax ?? 1000,
            instock: false,
        });
        onClearCallback?.();
    };
    const clearFiltersClick = () => {
        setName('');
        setEffects([]);
        setCost([filterLimits.cmin ?? 0, filterLimits.cmax ?? 1000]);
        setPrice([filterLimits.pmin ?? 0, filterLimits.pmax ?? 1000]);
        setInStock(false);
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
                    <TagSearchInput
                        value={effectQuery}
                        label='Effect'
                        route='effect/listing'
                        tags={effects}
                        idKey='effectId'
                        dataKey='name'
                        addTag={addEffect}
                        removeTag={removeEffect}
                        setValue={(newValue) => setEffectQuery(newValue)}
                    />
                </Form.Group>
                <Form.Group className='filter-group'>
                    <RangeSliderControl
                        value={cost}
                        id={'cost'}
                        label={'Cost'}
                        min={filterLimits.cmin ?? 0}
                        max={filterLimits.cmax ?? 1000}
                        onRangeChange={(e) => {
                            setCost(e);
                            setCostRange(e);
                        }}
                    />
                    <RangeSliderControl
                        value={price}
                        id={'price'}
                        label={'Price'}
                        min={filterLimits.pmin ?? 0}
                        max={filterLimits.pmax ?? 1000}
                        onRangeChange={(e) => {
                            setPrice(e);
                            setPriceRange(e);
                        }}
                    />
                </Form.Group>
            </Form>
            <Form.Group className='filter-toggles'>
                <CheckboxControl
                    value={inStock}
                    label={'In Stock'}
                    name={'instock'}
                    onChange={() => {
                        setInStock(!inStock);
                        setFilterByKey('instock', !inStock);
                    }}
                />
            </Form.Group>
            <ClearFilterButton clearFiltersClick={clearFiltersClick} />
        </div>
    );
};

export default PotionFilters;
