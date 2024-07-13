import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';
import { IActionButton, IListingColumn } from '../../../types/IListing';
import { QuillIcon } from '../../common/image/Icon';
import Listing from '../../common/listing/Listing';

const OrderListing = () => {
    const { user } = useAuth();
    // Set filters here
    const columns: IListingColumn[] = [
        {
            align: 'center',
            label: 'Receipt Number',
            dataKey: 'receiptNumber',
            colspan: 5,
        },
        {
            align: 'center',
            label: 'Order',
            dataKey: 'order',
            colspan: 5,
        },
        {
            align: 'center',
            label: 'Date Fulfilled',
            dataKey: 'dateFulfilled',
            colspan: 2,
        },
        {
            align: 'center',
            label: 'Employee',
            dataKey: 'employee',
            colspan: 3,
        },
        {
            align: 'center',
            label: 'Customer',
            dataKey: 'customer',
            colspan: 3,
        },
        {
            align: 'center',
            label: 'Total',
            dataKey: 'total',
            colspan: 2,
        },
    ];

    const rowButtons: IActionButton[] = [
        {
            color: 'blue',
            tooltip: 'View Receipt',
            icon: <QuillIcon />, // Maybe a different icon?
            argKey: 'receiptId',
            action: (id) => {
                console.log(id);
            },
        },
    ];

    const remove = async (selected: number[]) => {
        await axios.post('receipt/remove', selected, user?.authConfig);
    };

    return (
        <Listing
            id='receiptId'
            columns={columns}
            route={'receipt/listing'}
            remove={user?.roles.includes('Owner') ? remove : undefined}
            rowButtons={rowButtons}
        />
    );
};

export default OrderListing;
