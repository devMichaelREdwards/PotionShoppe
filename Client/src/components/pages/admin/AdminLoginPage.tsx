import { Container, Content, FlexboxGrid, Panel } from 'rsuite';
import FlexboxGridItem from 'rsuite/esm/FlexboxGrid/FlexboxGridItem';
import AdminLoginForm from '../../forms/AdminLoginForm';
import { Navigate, useLocation, useNavigate } from 'react-router-dom';
import useAuth from '../../../hooks/useAuth';
import { useEffect } from 'react';
import { refreshEmployee } from '../../../helpers/authenticate';
import { IAdminUser } from '../../../types/IUser';

const AdminLoginPage = () => {
    const { user, setUser } = useAuth();
    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || '/admin';
    useEffect(() => {
        const checkRefresh = async () => {
            const res = await refreshEmployee();
            if (res?.success) {
                const user: IAdminUser = {
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
                console.log(user);
                setUser(user);
                navigate(from, { replace: true });
            }
        };
        checkRefresh();
    });

    if (user) return <Navigate to='/admin' />;
    return (
        <div id='admin-login-page'>
            <Container>
                <Content>
                    <FlexboxGrid justify='center' align='middle'>
                        <FlexboxGridItem colspan={12}>
                            <Panel header='Potion Shoppe Employee' bordered>
                                <AdminLoginForm />
                            </Panel>
                        </FlexboxGridItem>
                    </FlexboxGrid>
                </Content>
            </Container>
        </div>
    );
};

export default AdminLoginPage;
