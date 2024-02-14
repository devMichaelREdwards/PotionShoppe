import useAuth from '../../../hooks/useAuth';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import Listing from '../../common/listing/Listing';

const EmployeeListing = () => {
    const { user } = useAuth();
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

    const rowButtons: IActionButton[] = [];

    if (user?.roles.includes('Owner')) {
        rowButtons.push({ label: 'Edit', appearance: 'primary', action: (id) => console.log(id), argKey: 'employeeId' });
    }

    return <Listing id='employeeId' columns={columns} route={'employee/listing'} rowButtons={rowButtons} />;
};

export default EmployeeListing;
