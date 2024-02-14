import { Route, Routes } from 'react-router-dom';
import EmployeeLoginPage from '../admin/pages/users/AdminLoginPage';
import AdminDashboardPage from '../admin/pages/general/DashboardPage';
import AdminRedirect from '../admin/redirect/AdminRedirect';
import { AuthProvider } from '../../context/AuthContext';
import CustomerListingPage from '../admin/pages/users/customers/CustomerListingPage';
import EmployeeListingPage from '../admin/pages/users/employees/EmployeeListingPage';
import IngredientListingPage from '../admin/pages/inventory/ingredients/IngredientListingPage';
import PotionListingPage from '../admin/pages/inventory/potions/PotionListingPage';
import IngredientFormPage from '../admin/pages/inventory/ingredients/IngredientFormPage';
import PotionFormPage from '../admin/pages/inventory/potions/PotionFormPage';
import OrderFormPage from '../admin/pages/orders/OrderFormPage';
import ReceiptFormPage from '../admin/pages/orders/ReceiptFormPage';
import EffectListingPage from '../admin/pages/inventory/effects/EffectListingPage';
import EffectFormPage from '../admin/pages/inventory/effects/EffectFormPage';
import CustomerFormPage from '../admin/pages/users/customers/CustomerFormPage';
import ReceiptListingPage from '../admin/pages/orders/ReceiptListingPage';
import OrderListingPage from '../admin/pages/orders/OrderListingPage';
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
