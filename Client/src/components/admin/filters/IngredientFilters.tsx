import { useState } from 'react';
import { IIngredientFilters } from '../../../types/IFilter';
import { debounce } from '../../../helpers/timing';
import { Form } from 'rsuite';
import { TextControl, RangeSliderControl, CheckboxControl, TagSearchInput } from '../../common/input/FormControl';
import { ICollectionObject } from '../../../types/IListing';
import FilterTitle from './FilterTitle';
import ClearFilterButton from './ClearFilterButton';

interface IProps {
    filters: IIngredientFilters;
    filterLimits: IIngredientFilters;
    setFilters: React.Dispatch<React.SetStateAction<IIngredientFilters>>;
    draw: number;
    onClearCallback?: () => void;
}

const IngredientFilters = ({ filters, filterLimits, setFilters, draw, onClearCallback }: IProps) => {
    const [name, setName] = useState('');
    const [categoryQuery, setCategoryQuery] = useState('');
    const [categories, setCategories] = useState<ICollectionObject[]>([]);
    const [effectQuery, setEffectQuery] = useState('');
    const [effects, setEffects] = useState<ICollectionObject[]>([]);
    const [cost, setCost] = useState<[number, number]>([filterLimits.cmin ?? 0, filterLimits.cmax ?? 1000]);
    const [price, setPrice] = useState<[number, number]>([filterLimits.pmin ?? 0, filterLimits.pmax ?? 1000]);
    const [inStock, setInStock] = useState(filterLimits.instock ?? false);

    const setFilterByKey = (key: keyof IIngredientFilters, value: string | number | boolean) => {
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

    const addCategory = (category: ICollectionObject) => {
        const newCategories = [...categories, category];
        setCategories(newCategories);
        setFilters({ ...filters, categories: newCategories.map((c) => c.id ?? 0) });
        onClearCallback?.();
    };

    const removeCategory = (id: number) => {
        const newCategories = [...categories.filter((c) => c.id !== id)];
        setCategories(newCategories);
        setFilters({ ...filters, categories: newCategories.map((c) => c.id ?? 0) });
        onClearCallback?.();
    };

    const clearFilters = () => {
        setFilters({
            name: '',
            categories: [],
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
        setCategories([]);
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
                <Form.Group className='filter-group'>
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
                        draw={draw}
                    />
                    <TagSearchInput
                        value={categoryQuery}
                        label='Category'
                        route='ingredientcategory'
                        tags={categories}
                        idKey='ingredientCategoryId'
                        dataKey='title'
                        addTag={addCategory}
                        removeTag={removeCategory}
                        setValue={(newValue) => setCategoryQuery(newValue)}
                        draw={draw}
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

export default IngredientFilters;
