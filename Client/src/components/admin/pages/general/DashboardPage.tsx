import { Container, Content } from 'rsuite';
import useTitle from '../../../../hooks/useTitle';
import AdminHeader from '../../../common/header/AdminHeader';

const AdminDashboardPage = () => {
    useTitle('Potion Shoppe Admin');
    return (
        <Container>
            <AdminHeader title='Dashboard' />
            <Content>Content</Content>
        </Container>
    );
};

export default AdminDashboardPage;
