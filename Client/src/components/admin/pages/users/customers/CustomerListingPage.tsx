import { Container, Content, Header, Panel } from 'rsuite';
import CustomerListing from '../../../listing/CustomerListing';
import useTitle from '../../../../../hooks/useTitle';

const CustomerListingPage = () => {
    useTitle('Customers');
    return (
        <Panel className='admin-page'>
            <Container>
                <Header>Customers</Header>
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
