import { Content, Panel } from 'rsuite';
import CustomerListing from '../../listing/CustomerListing';
import useTitle from '../../../../hooks/useTitle';
import AdminHeader from '../../../common/header/AdminHeader';
import CustomerFilters from '../../filters/CustomerFilters';
import { useEffect, useState } from 'react';
import { IAccountFilters } from '../../../../types/IFilter';

const CustomerPage = () => {
    useTitle('Customers');

    const [filters, setFilters] = useState<IAccountFilters>({});
    const [filterLimits, setFilterLimits] = useState<IAccountFilters>({});

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
            setFilterLimits({});
            setLoading(false);
        };
        getFilterData();
    }, [draw]);

    if (loading) return <>Loading Screen</>;

    return (
        <Panel className='admin-page'>
            <AdminHeader title='Customers' />
            {edit ? (
                <Content>{/* Customer form goes here */}</Content>
            ) : (
                <Content>
                    <CustomerFilters
                        filters={filters}
                        setFilters={setFilters}
                        onClearCallback={() => {
                            setDraw(draw + 1);
                        }}
                    />
                    {/* Later note: Some actions will require OWNER position*/}
                    <CustomerListing filters={filters} toggleEdit={toggleEdit} />
                </Content>
            )}
        </Panel>
    );
};

export default CustomerPage;
