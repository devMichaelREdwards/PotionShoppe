import { Outlet } from 'react-router-dom';
import { Container, Content } from 'rsuite';
import AdminSideBar from '../navbar/AdminSideBar';
import useTitle from '../../../hooks/useTitle';

const AdminLayout = () => {
    useTitle('Potion Shoppe Admin');

    return (
        <Container className='admin-panel'>
            <AdminSideBar />
            <Content>
                <Outlet />
            </Content>
        </Container>
    );
};

export default AdminLayout;
