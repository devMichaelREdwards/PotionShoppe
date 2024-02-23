import { Container, Content, Panel } from 'rsuite';
import EmployeeListing from '../../../listing/EmployeeListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const EmployeeListingPage = () => {
    useTitle('Employees');
    return (
        <Panel className='admin-page'>
            <Container>
                <AdminHeader title='Employees' />
                <Content>
                    <EmployeeFilters />
                    <EmployeeListing />
                </Content>
            </Container>
        </Panel>
    );
};

const EmployeeFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default EmployeeListingPage;
