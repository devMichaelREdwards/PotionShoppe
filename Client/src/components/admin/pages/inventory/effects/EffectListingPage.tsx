import { Content, Panel } from 'rsuite';
import EffectListing from '../../../listing/EffectListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const EffectListingPage = () => {
    useTitle('Effects');
    return (
        <Panel className='admin-page'>
            <AdminHeader title='Effects' />
            <Content>
                <EffectFilters />
                <EffectListing />
            </Content>
        </Panel>
    );
};

const EffectFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default EffectListingPage;
