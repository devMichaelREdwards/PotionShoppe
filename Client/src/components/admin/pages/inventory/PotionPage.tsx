import { Content, Panel } from 'rsuite';
import PotionListing from '../../listing/PotionListing';
import useTitle from '../../../../hooks/useTitle';
import AdminHeader from '../../../common/header/AdminHeader';
import { IIngredientFilters } from '../../../../types/IFilter';
import { useState, useEffect } from 'react';
import PotionFilters from '../../filters/PotionFilters';
import axios from '../../../../api/axios';
import PotionForm from '../../forms/PotionForm';

const PotionPage = () => {
    useTitle('Potions');

    const [filters, setFilters] = useState<IIngredientFilters>({});

    const [filterLimits, setFilterLimits] = useState<IIngredientFilters>({});

    const [loading, setLoading] = useState(true);

    const [draw, setDraw] = useState(0);

    const [edit, setEdit] = useState(false);

    const [editId, setEditId] = useState<number>(0);

    const toggleEdit = (active: boolean, editId?: number) => {
        setEdit(active);
        setEditId(editId ?? 0);
        setDraw(draw + 1);
    };

    useEffect(() => {
        const getFilterData = async () => {
            const response = await axios.get('potion/filters');
            const limits = response.data;
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

            {edit ? (
                <Content>
                    <PotionForm editId={editId} toggleEdit={toggleEdit} />
                </Content>
            ) : (
                <Content>
                    <PotionFilters
                        filters={{ ...filters }}
                        filterLimits={filterLimits}
                        setFilters={setFilters}
                        onClearCallback={() => {
                            setDraw(draw + 1);
                        }}
                    />
                    <PotionListing filters={{ ...filters }} toggleEdit={toggleEdit} />
                </Content>
            )}
        </Panel>
    );
};

export default PotionPage;
