import { Outlet } from 'react-router-dom';
import { Container } from 'rsuite';
import AdminSideBar from '../navbar/admin/AdminSideBar';
import useTitle from '../../hooks/useTitle';

const AdminLayout = () => {
    useTitle('Potion Shoppe Admin');
    return (
        <div className='employee-panel'>
            <Container>
                <AdminSideBar />
                <Outlet />
            </Container>
        </div>
    );
};

export default AdminLayout;
