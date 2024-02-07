import { Container, Content, FlexboxGrid, Panel } from 'rsuite';
import FlexboxGridItem from 'rsuite/esm/FlexboxGrid/FlexboxGridItem';
import AdminLoginForm from '../../forms/AdminLoginForm';
import { Navigate } from 'react-router-dom';
import useAuth from '../../../hooks/useAuth';

const AdminLoginPage = () => {
    const { user } = useAuth();

    // If the user is already logged in, send them to the dashboard
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
