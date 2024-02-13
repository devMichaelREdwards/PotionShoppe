import { Container, Content, Header } from 'rsuite';
import useTitle from '../../../../hooks/useTitle';

const AdminDashboardPage = () => {
    useTitle('Potion Shoppe Admin');
    return (
        <Container>
            <Header>
                <h2>Page Title</h2>
            </Header>
            <Content>Content</Content>
        </Container>
    );
};

export default AdminDashboardPage;
