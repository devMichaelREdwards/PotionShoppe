import { Content, Panel } from 'rsuite';
import PotionListing from '../../../listing/PotionListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';
import { IIngredientFilters } from '../../../../../types/IFilter';
import { useState, useEffect } from 'react';
import PotionFilters from '../../../filters/PotionFilters';
import axios from '../../../../../api/axios';

const PotionListingPage = () => {
    useTitle('Potions');

    const [filters, setFilters] = useState<IIngredientFilters>({});

    const [filterLimits, setFilterLimits] = useState<IIngredientFilters>({});

    const [loading, setLoading] = useState(true);

    const [draw, setDraw] = useState(0);

    useEffect(() => {
        const getFilterData = async () => {
            const response = await axios.get('potion/filters');

            const limits = response.data;
            console.log(limits);
            setFilterLimits({
                cmax: limits.costMax,
                pmax: limits.priceMax,
            });
            setLoading(false);
        };

        getFilterData();
    }, [draw]);

    if (loading) return <>Loading Screen</>;
    return (
        <Panel className='admin-page'>
            <AdminHeader title='Potions' />
            <Content>
                <PotionFilters
                    filters={{ ...filters }}
                    filterLimits={filterLimits}
                    setFilters={setFilters}
                    onClearCallback={() => {
                        setDraw(draw + 1);
                    }}
                />
                <PotionListing filters={{ ...filters }} />
            </Content>
        </Panel>
    );
};

export default PotionListingPage;
