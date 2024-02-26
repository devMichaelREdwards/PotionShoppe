import { Content, Panel } from 'rsuite';
import ReceiptListing from '../../../listing/ReceiptListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const ReceiptListingPage = () => {
    useTitle('Receipts');
    return (
        <Panel className='admin-page'>
            <AdminHeader title='Receipts' />
            <Content>
                <ReceiptFilters />
                <ReceiptListing />
            </Content>
        </Panel>
    );
};

const ReceiptFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default ReceiptListingPage;
