import { Container, Content, Footer, Header } from 'rsuite';
import EffectListing from './EffectListing';
import setTitle from '../../../../../helpers/setTitle';

const EffectListingPage = () => {
    setTitle('Effects');
    return (
        <div className='admin-page'>
            <Container>
                <Header>Effects</Header>
                <Content>
                    <EffectFilters />
                    <EffectListing />
                </Content>
                <Footer></Footer>
            </Container>
        </div>
    );
};

const EffectFilters = () => {
    return <div className='filters'>Filters</div>;
};

export default EffectListingPage;
