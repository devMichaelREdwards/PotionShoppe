import { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { refreshEmployee } from '../../../helpers/authenticate';
import AdminLayout from '../layout/AdminLayout';
import useAuth from '../../../hooks/useAuth';
import { IAdminUser } from '../../../types/IUser';

interface IRedirectProps {
    allowedRoles?: string[];
}

const AdminRedirect: React.FC<IRedirectProps> = ({ allowedRoles }: IRedirectProps) => {
    const { user, setUser } = useAuth();
    const [authorized, setAuthorized] = useState(false);
    const [loading, setLoading] = useState(true);
    const location = useLocation();
    const navigate = useNavigate();
    useEffect(() => {
        const askServer = async () => {
            const res = await refreshEmployee();
            if (res?.success) {
                const refreshedUser: IAdminUser = {
                    userName: res.userName,
                    token: res?.token,
                    loggedIn: true,
                    authConfig: {
                        headers: {
                            Authorization: `Bearer ${res.token}`,
                        },
                    },
                    roles: res.roles,
                };
                setAuthorized(true);
                if (!user) setUser(refreshedUser);
                setLoading(false);
            } else {
                navigate('login');
            }
        };
        askServer();
    }, [user, loading, authorized, allowedRoles, location]);

    if (loading) return <>Authorization Loading Page</>;
    return <AdminLayout />;
};

export default AdminRedirect;
