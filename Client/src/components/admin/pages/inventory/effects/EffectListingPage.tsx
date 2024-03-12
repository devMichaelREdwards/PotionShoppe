import { Content } from 'rsuite';
import EffectListing from '../../../listing/EffectListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';
import { IEffectFilters } from '../../../../../types/IFilter';
import { useEffect, useState } from 'react';
import { debounce } from '../../../../../helpers/timing';
import axios from '../../../../../api/axios';
import EffectFilters from '../../../filters/EffectFilters';

const EffectListingPage = () => {
    useTitle('Effects');

    const [filters, setFilters] = useState<IEffectFilters>({});

    const [filterLimits, setFilterLimits] = useState<IEffectFilters>({});

    const [loading, setLoading] = useState(true);

    const [draw, setDraw] = useState(0);

    useEffect(() => {
        const getFilterData = async () => {
            const response = await axios.get('effect/filters');
            const limits = response.data;
            setFilterLimits({
                vmax: limits.valueMax,
                dmax: limits.durationMax,
            });
            setLoading(false);
        };

        getFilterData();
    }, [draw]);

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
        setDraw(draw + 1);
        setFilters({
            name: '',
            vmin: filterLimits.vmin ?? 0,
            vmax: filterLimits.vmax ?? 1000,
            dmin: filterLimits.dmin ?? 0,
            dmax: filterLimits.dmax ?? 1000,
        });
    };

    if (loading) return <>Loading Screen</>;

    return (
        <div className='admin-page'>
            <AdminHeader title='Effects' />
            <Content>
                <EffectFilters
                    filterLimits={filterLimits}
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

export default EffectListingPage;
