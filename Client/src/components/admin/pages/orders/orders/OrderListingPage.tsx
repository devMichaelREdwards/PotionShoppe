import { Content, Panel } from 'rsuite';
import OrderListing from '../../../listing/OrderListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const OrderListingPage = () => {
    useTitle('Orders');
    return (
        <Panel className='admin-page'>
            <AdminHeader title='Orders' />
            <Content>
                <OrderFilters />
                <OrderListing />
            </Content>
        </Panel>
    );
};

const OrderFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default OrderListingPage;
