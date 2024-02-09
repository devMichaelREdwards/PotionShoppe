import { Outlet } from 'react-router-dom';
import { Container } from 'rsuite';
import AdminSideBar from '../navbar/admin/AdminSideBar';

const AdminLayout = () => {
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
