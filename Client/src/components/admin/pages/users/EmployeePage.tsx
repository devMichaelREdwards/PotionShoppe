import { Container, Content, Panel } from 'rsuite';
import AdminHeader from '../../../common/header/AdminHeader';
import EmployeeListing from '../../listing/EmployeeListing';
import useTitle from '../../../../hooks/useTitle';
import EmployeeFilters from '../../filters/EmployeeFilters';
import { useState, useEffect } from 'react';
import { IAccountFilters } from '../../../../types/IFilter';

const EmployeePage = () => {
    useTitle('Employees');

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
            <Container>
                <AdminHeader title='Employees' />
                <Content>
                    <EmployeeFilters
                        filters={filters}
                        setFilters={setFilters}
                        onClearCallback={() => {
                            setDraw(draw + 1);
                        }}
                    />
                    <EmployeeListing filters={filters} toggleEdit={toggleEdit} />
                </Content>
            </Container>
        </Panel>
    );
};

export default EmployeePage;
