import { Content, Panel } from 'rsuite';
import IngredientListing from '../../../listing/IngredientListing';
import useTitle from '../../../../../hooks/useTitle';
import AdminHeader from '../../../../common/header/AdminHeader';

const IngredientListingPage = () => {
    useTitle('Ingredients');
    return (
        <Panel className='admin-page'>
            <AdminHeader title='Ingredients' />
            <Content>
                <IngredientFilters />
                <IngredientListing />
            </Content>
        </Panel>
    );
};

const IngredientFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default IngredientListingPage;
