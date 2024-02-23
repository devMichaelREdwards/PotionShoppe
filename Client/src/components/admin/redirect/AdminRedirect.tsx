import { useState, useEffect } from 'react';
import { Navigate, useLocation } from 'react-router-dom';
import { authenticateEmployee, refreshEmployee } from '../../../helpers/authenticate';
import AdminLayout from '../layout/AdminLayout';
import useAuth from '../../../hooks/useAuth';

interface IRedirectProps {
    allowedRoles?: string[];
}

const AdminRedirect: React.FC<IRedirectProps> = ({ allowedRoles }: IRedirectProps) => {
    const { user } = useAuth();
    const [authorized, setAuthorized] = useState(false);
    const [loading, setLoading] = useState(true);
    const location = useLocation();
    useEffect(() => {
        const askServer = async () => {
            const authorized =
                user && user.roles.find((role) => allowedRoles?.includes(role)) && ((await authenticateEmployee(user)) || (await refreshEmployee()));
            setLoading(false);
            setAuthorized(authorized);
        };
        askServer();
    }, [user, loading, authorized, allowedRoles, location]);

    if (loading) return <>Authorization Loading Page</>;
    return authorized ? <AdminLayout /> : <Navigate to='/admin/login' />;
};

export default AdminRedirect;
