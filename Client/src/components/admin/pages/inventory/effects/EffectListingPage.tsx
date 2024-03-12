import { Button, Content, Form } from 'rsuite';
import EffectListing from '../../../listing/EffectListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';
import { IEffectFilters } from '../../../../../types/IFilter';
import { RangeSliderControl, TextControl } from '../../../../common/input/FormControl';
import { useState } from 'react';
import { debounce } from '../../../../../helpers/timing';

const EffectListingPage = () => {
    useTitle('Effects');

    const [filters, setFilters] = useState<IEffectFilters>({});

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
        // Reset constraints here as well?
        setFilters({
            name: '',
            vmin: 0,
            vmax: 1000,
            dmin: 0,
            dmax: 1000,
        });
    };

    return (
        <div className='admin-page'>
            <AdminHeader title='Effects' />
            <Content>
                <EffectFilters
                    setFilterByKey={setFilterByKey}
                    setValueRange={setValueRange}
                    setDurationRange={setDurationRange}
                    clearFilters={clearFilters}
                />
                <EffectListing filters={filters} />
            </Content>
        </div>
    );
};

interface IEffectFiltersProps {
    setFilterByKey: (key: keyof IEffectFilters, value: string | number) => void;
    setValueRange: (range: [number, number]) => void;
    setDurationRange: (range: [number, number]) => void;
    clearFilters: () => void;
}

const EffectFilters = ({ setFilterByKey, setValueRange, setDurationRange, clearFilters }: IEffectFiltersProps) => {
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
                    label={'Value'}
                    min={0}
                    max={100}
                    onRangeChange={(e) => {
                        setValueRange(e);
                    }}
                />
                <RangeSliderControl
                    label={'Duration'}
                    min={0}
                    max={100}
                    onRangeChange={(e) => {
                        setDurationRange(e);
                    }}
                />
            </Form.Group>

            <Button onClick={clearFiltersClick}>Clear Filters</Button>
        </Form>
    );
};

export default EffectListingPage;
