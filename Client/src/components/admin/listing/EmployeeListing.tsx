import useAuth from '../../../hooks/useAuth';
import { IAccountFilters } from '../../../types/IFilter';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { QuillIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';

interface IProps {
    filters: IAccountFilters;
    toggleEdit: (active: boolean, editId?: number) => void;
}

const EmployeeListing = ({ filters }: IProps) => {
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
            label: 'Position',
            dataKey: 'employeePosition',
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
            dataKey: 'employeeStatus',
            colspan: 3,
        },
    ];

    const rowButtons: IActionButton[] = [];

    if (user?.roles.includes('Owner')) {
        rowButtons.push({ color: 'blue', icon: <QuillIcon />, action: (id) => console.log(id), argKey: 'customerId', tooltip: 'Edit Employee' });
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

        if (filters.positions !== undefined && filters.positions.length > 0) {
            if (addFilters) filterString += `&`;
            else addFilters = true;
            let idString = '';
            filters.positions.forEach((eff, i) => {
                idString += eff;
                if (i < filters.positions!.length - 1) {
                    idString += ',';
                }
            });
            filterString += `positions=${idString}`;
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

    return <Listing id='employeeId' columns={columns} route={'employee/listing'} rowButtons={rowButtons} filterString={buildFilterString(filters)} />;
};

export default EmployeeListing;
