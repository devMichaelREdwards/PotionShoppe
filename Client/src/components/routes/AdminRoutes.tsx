import { Route, Routes } from 'react-router-dom';
import EmployeeLoginPage from '../pages/admin/AdminLoginPage';
import AdminDashboardPage from '../pages/admin/AdminDashboardPage';
import AdminRedirect from '../redirect/AdminRedirect';
import { AuthProvider } from '../../context/AuthContext';

const AdminRoutes = () => {
    return (
        <AuthProvider>
            <Routes>
                <Route path='/*' element={null} />
                <Route path='admin/login' element={<EmployeeLoginPage />} />
                <Route path='admin/logout' element={<>Logout Page</>} />
                <Route path='admin' element={<AdminRedirect allowedRoles={['Employee']} />}>
                    {/* These roles should probably not be strings, just to make the JS harder to determine? */}
                    <Route path='' element={<AdminDashboardPage />} />
                </Route>
                <Route path='admin' element={<AdminRedirect allowedRoles={['Owner']} />}>
                    <Route path='' element={<AdminDashboardPage />} />
                </Route>
            </Routes>
        </AuthProvider>
    );
};

export default AdminRoutes;
