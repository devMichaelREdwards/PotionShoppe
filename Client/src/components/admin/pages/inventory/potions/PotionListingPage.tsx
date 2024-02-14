import { Content, Panel } from 'rsuite';
import PotionListing from '../../../listing/PotionListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const PotionListingPage = () => {
    useTitle('Potions');
    return (
        <Panel className='admin-page'>
            <AdminHeader title='Potions' />
            <Content>
                <PotionFilters />
                <PotionListing />
            </Content>
        </Panel>
    );
};

const PotionFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default PotionListingPage;
