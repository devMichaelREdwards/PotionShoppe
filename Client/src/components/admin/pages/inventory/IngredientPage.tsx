import { Content, Panel } from 'rsuite';
import IngredientListing from '../../listing/IngredientListing';
import useTitle from '../../../../hooks/useTitle';
import AdminHeader from '../../../common/header/AdminHeader';
import { IIngredientFilters } from '../../../../types/IFilter';
import axios from '../../../../api/axios';
import { useEffect, useState } from 'react';
import IngredientFilters from '../../filters/IngredientFilters';
import IngredientForm from '../../forms/IngredientForm';

const IngredientPage = () => {
    useTitle('Ingredients');

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
            const response = await axios.get('ingredient/filters');

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
            <AdminHeader title='Ingredients' />
            <Content>
                {edit ? (
                    <IngredientForm editId={editId} toggleEdit={toggleEdit} />
                ) : (
                    <>
                        <IngredientFilters
                            filters={{ ...filters }}
                            filterLimits={filterLimits}
                            setFilters={setFilters}
                            onClearCallback={() => {
                                setDraw(draw + 1);
                            }}
                        />
                        <IngredientListing filters={{ ...filters }} toggleEdit={toggleEdit} />
                    </>
                )}
            </Content>
        </Panel>
    );
};

export default IngredientPage;
