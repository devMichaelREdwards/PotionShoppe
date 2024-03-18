import { useState } from 'react';
import { IIngredientFilters } from '../../../types/IFilter';
import { debounce } from '../../../helpers/timing';
import { MagicWandIcon } from '../../common/image/Icon';
import { Form } from 'rsuite';
import ActionButton from '../../common/input/ActionButton';
import { TextControl, RangeSliderControl, CheckboxControl } from '../../common/input/FormControl';

interface IProps {
    filters: IIngredientFilters;
    filterLimits: IIngredientFilters;
    setFilters: React.Dispatch<React.SetStateAction<IIngredientFilters>>;
    onClearCallback?: () => void;
}

const IngredientFilters = ({ filters, filterLimits, setFilters, onClearCallback }: IProps) => {
    const [name, setName] = useState('');
    const [category, setCategory] = useState(0);
    const [effect, setEffect] = useState(0);
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

    const clearFilters = () => {
        setFilters({
            name: '',
            category: 0,
            effect: 0,
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
        setCategory(0);
        setEffect(0);
        setCost([filterLimits.cmin ?? 0, filterLimits.cmax ?? 1000]);
        setPrice([filterLimits.pmin ?? 0, filterLimits.pmax ?? 1000]);
        setInStock(false);
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
            </Form>
            <div className='clear-filters-button'>
                <ActionButton color={'red'} appearance={'ghost'} label={'Clear Filters'} action={clearFiltersClick} />
            </div>
        </div>
    );
};

export default IngredientFilters;
