import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { refreshEmployee } from '../../../helpers/authenticate';
import AdminLayout from '../layout/AdminLayout';
import useAuth from '../../../hooks/useAuth';
import { IAdminUser } from '../../../types/IUser';

interface IRedirectProps {
    allowedRoles?: string[];
}

const AdminRedirect: React.FC<IRedirectProps> = ({ allowedRoles }: IRedirectProps) => {
    const { setUser } = useAuth();
    const [authorized, setAuthorized] = useState(false);
    const [loading, setLoading] = useState(true);
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

                if (refreshedUser.roles.find((role) => allowedRoles?.includes(role))) {
                    setAuthorized(true);
                    setUser(refreshedUser);
                } else {
                    navigate(''); // Send back to dashboard
                }
                setLoading(false);
            } else {
                navigate('login');
            }
        };
        askServer();
    }, [allowedRoles, navigate, setUser]);

    if (loading) return <>Authorization Loading Page</>;
    return authorized && <AdminLayout />;
};

export default AdminRedirect;
