import { Container, Content, Footer, Header } from 'rsuite';
import CustomerListing from '../../../listing/CustomerListing';
import useTitle from '../../../../../hooks/useTitle';

const CustomerListingPage = () => {
    useTitle('Customers');
    return (
        <div className='admin-page'>
            <Container>
                <Header>Customers</Header>
                <Content>
                    <CustomerFilters />
                    <CustomerListing />
                </Content>
                <Footer></Footer>
            </Container>
        </div>
    );
};

const CustomerFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default CustomerListingPage;
