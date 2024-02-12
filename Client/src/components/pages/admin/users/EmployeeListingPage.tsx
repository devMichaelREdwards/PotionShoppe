import { Container, Content, Footer, Header } from 'rsuite';
import Listing from '../../../common/listing/Listing';
import { IListingColumn } from '../../../../types/IListing';

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

const EmployeeListing = () => {
    const columns: IListingColumn[] = [
        {
            align: 'left',
            label: 'First Name',
            dataKey: 'firstName',
            colspan: 3,
        },
        {
            align: 'left',
            label: 'Last Name',
            dataKey: 'lastName',
            colspan: 3,
        },
        {
            align: 'left',
            label: 'Username',
            dataKey: 'userName',
            colspan: 3,
        },
        {
            align: 'left',
            label: 'Position',
            dataKey: 'employeePosition',
            colspan: 3,
        },
        {
            align: 'left',
            label: 'Status',
            dataKey: 'employeeStatus',
            colspan: 3,
        },
    ];

    return (
        <div className='listing'>
            <Listing id='employeeId' columns={columns} route={'employee/employee-listing'} openModal={() => null} />
        </div>
    );
};

export default EmployeeListingPage;
