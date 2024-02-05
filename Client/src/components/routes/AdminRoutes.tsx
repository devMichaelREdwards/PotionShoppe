import { Route, Routes } from 'react-router-dom';
import EmployeeLoginPage from '../pages/admin/AdminLoginPage';

const AdminRoutes = () => {
    return (
        <Routes>
            <Route path='/*' element={null} />
            <Route path='admin/login' element={<EmployeeLoginPage />} />
        </Routes>
    );
};

export default AdminRoutes;
