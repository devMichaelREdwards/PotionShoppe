import { Container, Content, Panel } from 'rsuite';
import CustomerListing from '../../../listing/CustomerListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const CustomerListingPage = () => {
    useTitle('Customers');
    return (
        <Panel className='admin-page'>
            <Container>
                <AdminHeader title='Customers' />
                <Content>
                    <CustomerFilters />
                    <CustomerListing />
                </Content>
            </Container>
        </Panel>
    );
};

const CustomerFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default CustomerListingPage;
