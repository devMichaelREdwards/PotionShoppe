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
            label: 'Order Number',
            dataKey: 'orderNumber',
            colspan: 4,
        },
        {
            align: 'center',
            label: 'Customer',
            dataKey: 'customer',
            colspan: 4,
        },
        {
            align: 'center',
            label: 'Date Placed',
            dataKey: 'datePlaced',
            colspan: 2,
        },
        {
            align: 'center',
            label: 'Status',
            dataKey: 'orderStatus',
            colspan: 2,
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
            tooltip: 'Edit Order',
            icon: <QuillIcon />,
            argKey: 'orderId',
            action: (id) => {
                console.log(id);
            },
        },
    ];

    const remove = async (selected: number[]) => {
        await axios.post('order/remove', selected, user?.authConfig);
    };

    return (
        <Listing
            id='orderId'
            columns={columns}
            route={'order/listing'}
            remove={user?.roles.includes('Owner') ? remove : undefined}
            removeTooltip='Delete Orders'
            rowButtons={rowButtons}
        />
    );
};

export default OrderListing;
