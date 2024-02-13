import { Container, Content, Footer, Header } from 'rsuite';
import EffectListing from './EffectListing';
import useTitle from '../../../../../hooks/useTitle';

const EffectListingPage = () => {
    useTitle('Effects');
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
