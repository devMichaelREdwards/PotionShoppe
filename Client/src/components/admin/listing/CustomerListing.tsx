import useAuth from '../../../hooks/useAuth';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import Listing from '../../common/listing/Listing';

const CustomerListing = () => {
    const { user } = useAuth();
    const columns: IListingColumn[] = [
        {
            align: 'center',
            label: 'First Name',
            dataKey: 'firstName',
            colspan: 3,
        },
        {
            align: 'center',
            label: 'Last Name',
            dataKey: 'lastName',
            colspan: 3,
        },
        {
            align: 'center',
            label: 'Username',
            dataKey: 'userName',
            colspan: 3,
        },
        {
            align: 'center',
            label: 'Status',
            dataKey: 'customerStatus',
            colspan: 3,
        },
    ];

    const rowButtons: IActionButton[] = [];

    if (user?.roles.includes('Owner')) {
        rowButtons.push({ label: 'Edit', appearance: 'primary', action: (id) => console.log(id), argKey: 'customerId' });
    }

    return <Listing id='customerId' columns={columns} route={'customer/listing'} rowButtons={rowButtons} />;
};

export default CustomerListing;
