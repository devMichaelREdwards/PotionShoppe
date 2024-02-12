import { Container, Content, Footer, Header } from 'rsuite';
import EffectListing from './EffectListing';

const EffectListingPage = () => {
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
