import { Container, Content, Footer, Header } from 'rsuite';
import EmployeeListing from './EmployeeListing';

const EmployeeListingPage = () => {
    return (
        <div className='admin-page'>
            <Container>
                <Header>Employees</Header>
                <Content>
                    <EmployeeFilters />
                    <EmployeeListing />
                </Content>
                <Footer></Footer>
            </Container>
        </div>
    );
};

const EmployeeFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default EmployeeListingPage;
