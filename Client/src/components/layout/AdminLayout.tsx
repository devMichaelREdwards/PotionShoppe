import { Outlet } from 'react-router-dom';

const AdminLayout = () => {
    return (
        <>
            <div>Admin Page Layout Component</div>
            <Outlet />
        </>
    );
};

export default AdminLayout;
