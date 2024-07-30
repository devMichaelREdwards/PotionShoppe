import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IData } from '../../../types/IData';
import { IAccountFilters } from '../../../types/IFilter';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { QuillIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';

interface IProps {
    filters: IAccountFilters;
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
        rowButtons.push({
            argKey: 'customerId',
            isToggle: true,
            tooltip: 'Toggle Customer',
            currentValue: false,
            action: async (data) => {
                const collected = data as IData;
                const post = {
                    customerId: collected.id,
                    active: !collected.currentValue,
                };
                // Add confirmation to this later...

                await axios.post('customer/toggle', post, user?.authConfig);
            },
        });
        rowButtons.push({
            color: 'blue',
            icon: <QuillIcon />,
            action: (id) => console.log(id),
            tooltip: 'Add Customer',
            argKey: 'customerId',
        });
    }

    const buildFilterString = (filters: IAccountFilters) => {
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
