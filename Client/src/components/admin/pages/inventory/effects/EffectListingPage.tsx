import { Content, Panel } from 'rsuite';
import EffectListing from '../../../listing/EffectListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';
import { IEffectFilters } from '../../../../../types/IFilter';
import { useEffect, useState } from 'react';
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

    if (loading) return <>Loading Screen</>;

    return (
        <Panel className='admin-page'>
            <AdminHeader title='Effects' />
            <Content>
                <EffectFilters
                    filters={filters}
                    filterLimits={filterLimits}
                    setFilters={setFilters}
                    onClearCallback={() => {
                        setDraw(draw + 1);
                    }}
                />
                <EffectListing filters={filters} />
            </Content>
        </Panel>
    );
};

export default EffectListingPage;
