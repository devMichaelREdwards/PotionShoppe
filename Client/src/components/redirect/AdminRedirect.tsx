import { useState, useEffect } from 'react';
import { Navigate } from 'react-router-dom';
import { authenticateEmployee } from '../../helpers/authenticate';
import AdminLayout from '../layout/AdminLayout';
import useAuth from '../../hooks/useAuth';

interface IRedirectProps {
    allowedRoles?: string[];
}

const AdminRedirect: React.FC<IRedirectProps> = ({ allowedRoles }: IRedirectProps) => {
    const { user } = useAuth();
    const [authorized, setAuthorized] = useState(false);
    const [loading, setLoading] = useState(true);
    useEffect(() => {
        const askServer = async () => {
            const authorized = user && user.roles.find((role) => allowedRoles?.includes(role)) && (await authenticateEmployee(user));
            setLoading(false);
            setAuthorized(authorized);
        };
        if (loading && !authorized) askServer();
    }, [user, loading, authorized, allowedRoles]);
    if (loading) return <>Loading...</>;
    return authorized ? <AdminLayout /> : <Navigate to='login' />;
};

export default AdminRedirect;
