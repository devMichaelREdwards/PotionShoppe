import { Container, Content, Footer, Header, Panel } from 'rsuite';
import AdminLoginForm from '../../forms/AdminLoginForm';
import { Navigate, useLocation, useNavigate } from 'react-router-dom';
import useAuth from '../../../../hooks/useAuth';
import { useEffect } from 'react';
import { refreshEmployee } from '../../../../helpers/authenticate';
import { IAdminUser } from '../../../../types/IUser';
import useTitle from '../../../../hooks/useTitle';
import CopyrightText from '../../../common/information/CopyrightText';

const AdminLoginPage = () => {
    const { user, setUser } = useAuth();
    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || '/admin';
    useTitle('Employee Login');
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
                setUser(user);
                navigate(from, { replace: true });
            }
        };

        checkRefresh();
    });

    if (user) return <Navigate to='/admin' />;
    return (
        <Container className='admin-login-page'>
            <Header>
                <EmployeeLoginLogo />
            </Header>
            <Content>
                <Panel className='admin-login-panel'>
                    <AdminLoginForm />
                </Panel>
            </Content>
            <Footer>
                <CopyrightText />
            </Footer>
        </Container>
    );
};

const EmployeeLoginLogo = () => {
    return (
        <div className='login-logo'>
            <img src='/assets/employee/Employee_Login_Heading.png' />
        </div>
    );
};
export default AdminLoginPage;
