import { Route, Routes } from 'react-router-dom';
import EmployeeLoginPage from '../admin/pages/users/AdminLoginPage';
import AdminDashboardPage from '../admin/pages/general/DashboardPage';
import AdminRedirect from '../admin/redirect/AdminRedirect';
import { AuthProvider } from '../../context/AuthContext';
import CustomerListingPage from '../admin/pages/users/customers/CustomerListingPage';
import EmployeeListingPage from '../admin/pages/users/employees/EmployeeListingPage';
import IngredientPage from '../admin/pages/inventory/IngredientPage';
import PotionPage from '../admin/pages/inventory/PotionPage';
import EffectPage from '../admin/pages/inventory/EffectPage';
import CustomerFormPage from '../admin/pages/users/customers/CustomerFormPage';
import ReceiptListingPage from '../admin/pages/orders/receipts/ReceiptListingPage';
import OrderListingPage from '../admin/pages/orders/orders/OrderListingPage';
import EmployeeFormPage from '../admin/pages/users/employees/EmployeeForm';

const AdminRoutes = () => {
    return (
        <AuthProvider>
            <Routes>
                <Route path='/*' element={null} />
                <Route path='admin/login' element={<EmployeeLoginPage />} />
                <Route path='admin/logout' element={<>Logout Page</>} />
                <Route path='admin' element={<AdminRedirect allowedRoles={['Employee']} />}>
                    {/* These roles should probably not be plain strings, just to make the JS harder to determine?
                        Loaded from where? */}
                    <Route path='' element={<AdminDashboardPage />} />
                    <Route path='customers' element={<CustomerListingPage />} />
                    <Route path='employees' element={<EmployeeListingPage />} />
                    <Route path='potions' element={<PotionPage />} />
                    <Route path='ingredients' element={<IngredientPage />} />
                    <Route path='effects' element={<EffectPage />} />
                    <Route path='orders' element={<OrderListingPage />} />
                    <Route path='receipts' element={<ReceiptListingPage />} />
                </Route>
                <Route path='admin' element={<AdminRedirect allowedRoles={['Owner']} />}>
                    <Route path='' element={<AdminDashboardPage />} />
                    <Route path='customers/*' element={<CustomerFormPage />} />
                    <Route path='employees/*' element={<EmployeeFormPage />} />
                </Route>
            </Routes>
        </AuthProvider>
    );
};

export default AdminRoutes;
