import { useState } from 'react';
import axios from '../../../api/axios';
import { IAdminUser } from '../../../types/IUser';
import { ButtonToolbar, Form, Message, useToaster } from 'rsuite';
import useAuth from '../../../hooks/useAuth';
import { useLocation, useNavigate } from 'react-router-dom';
import { TextControl, PasswordControl } from '../../common/input/FormControl';
import ImageButton from '../../common/input/ImageButton';

const AdminLoginForm = () => {
    const { setUser } = useAuth();
    const navigate = useNavigate();
    const toaster = useToaster();
    const location = useLocation();
    const from = location.state?.from?.pathname || '/admin';
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [loading, setLoading] = useState(false);
    const handleLogin = async () => {
        setLoading(true);
        const loginData = {
            userName,
            password,
        };
        await axios
            .post('user/employee/login', loginData, { withCredentials: true })
            .then((res) => {
                // Login successful
                const user: IAdminUser = {
                    userName,
                    token: res.data.token,
                    loggedIn: true,
                    authConfig: {
                        headers: {
                            Authorization: `Bearer ${res.data.token}`,
                        },
                    },
                    roles: res.data.roles,
                };
                setUser(user);
                navigate(from, { replace: true });
            })
            .catch((error) => {
                toaster.push(<Message type='error'>{error.response.data}</Message>, { duration: 5000 });
                setLoading(false);
            });
    };
    return (
        <Form fluid>
            <Form.Group>
                <TextControl
                    value={userName}
                    label='Username'
                    name='userName'
                    onChange={(e: string) => {
                        setUserName(e);
                    }}
                />
            </Form.Group>
            <Form.Group>
                <PasswordControl
                    value={password}
                    label='Password'
                    name='password'
                    onChange={(e: string) => {
                        setPassword(e);
                    }}
                />
            </Form.Group>
            <Form.Group>
                <ButtonToolbar className='admin-login-button-wrapper'>
                    <ImageButton className='admin-login-button' src='/assets/employee/Burned_Parchment.png' onClick={handleLogin} loading={loading} />
                </ButtonToolbar>
            </Form.Group>
        </Form>
    );
};

export default AdminLoginForm;
