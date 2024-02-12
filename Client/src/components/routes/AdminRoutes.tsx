import { Route, Routes } from 'react-router-dom';
import EmployeeLoginPage from '../pages/admin/users/AdminLoginPage';
import AdminDashboardPage from '../pages/admin/general/DashboardPage';
import AdminRedirect from '../redirect/AdminRedirect';
import { AuthProvider } from '../../context/AuthContext';
import CustomerListingPage from '../pages/admin/users/customers/CustomerListingPage';
import EmployeeListingPage from '../pages/admin/users/employees/EmployeeListingPage';
import IngredientListingPage from '../pages/admin/inventory/IngredientListingPage';
import PotionListingPage from '../pages/admin/inventory/PotionListingPage';
import IngredientFormPage from '../pages/admin/inventory/IngredientFormPage';
import PotionFormPage from '../pages/admin/inventory/PotionFormPage';
import OrderFormPage from '../pages/admin/orders/OrderFormPage';
import ReceiptFormPage from '../pages/admin/orders/ReceiptFormPage';
import EffectListingPage from '../pages/admin/inventory/EffectListingPage';
import EffectFormPage from '../pages/admin/inventory/EffectFormPage';
import CustomerFormPage from '../pages/admin/users/customers/CustomerFormPage';
import ReceiptListingPage from '../pages/admin/orders/ReceiptListingPage';
import OrderListingPage from '../pages/admin/orders/OrderListingPage';
import EmployeeFormPage from '../pages/admin/users/employees/EmployeeForm';

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
                    <Route path='potions' element={<PotionListingPage />} />
                    <Route path='potions/*' element={<PotionFormPage />} />
                    <Route path='ingredients' element={<IngredientListingPage />} />
                    <Route path='ingredients/*' element={<IngredientFormPage />} />
                    <Route path='effects' element={<EffectListingPage />} />
                    <Route path='effects/*' element={<EffectFormPage />} />
                    <Route path='orders' element={<OrderListingPage />} />
                    <Route path='orders/*' element={<OrderFormPage />} />
                    <Route path='receipts' element={<ReceiptListingPage />} />
                    <Route path='receipts/*' element={<ReceiptFormPage />} />
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
