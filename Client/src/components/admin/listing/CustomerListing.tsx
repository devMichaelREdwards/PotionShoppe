import useAuth from '../../../hooks/useAuth';
import { ICustomerFilters } from '../../../types/IFilter';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import Listing from '../../common/listing/Listing';

interface IProps {
    filters: ICustomerFilters;
    toggleEdit: (active: boolean, editId?: number) => void;
}

const CustomerListing = ({ filters }: IProps) => {
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
            label: 'Email',
            dataKey: 'email',
            colspan: 5,
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

    const buildFilterString = (filters: ICustomerFilters) => {
        let addFilters = false;
        let filterString = '';
        if (filters.firstName) {
            addFilters = true;
            filterString += `firstName=${filters.firstName}`;
        }

        if (filters.lastName) {
            if (addFilters) filterString += `&`;
            addFilters = true;
            filterString += `lastName=${filters.lastName}`;
        }

        if (filters.userName) {
            if (addFilters) filterString += `&`;
            addFilters = true;
            filterString += `userName=${filters.userName}`;
        }

        if (filters.email) {
            if (addFilters) filterString += `&`;
            addFilters = true;
            filterString += `email=${filters.email}`;
        }

        if (filters.active) {
            if (addFilters) filterString += `&`;
            addFilters = true;
            filterString += `status=1`;
        }

        if (filters.banned) {
            if (addFilters) filterString += `&`;
            addFilters = true;
            filterString += `status=2`;
        }

        return addFilters ? filterString : '';
    };

    return <Listing id='customerId' columns={columns} route={'customer/listing'} rowButtons={rowButtons} filterString={buildFilterString(filters)} />;
};

export default CustomerListing;
