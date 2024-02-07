import { useState } from 'react';
import axios from '../../api/axios';
import { HttpStatusCode } from 'axios';
import { IAdminUser } from '../../types/IUser';
import { Button, ButtonToolbar, Form } from 'rsuite';
import useAuth from '../../hooks/useAuth';
import { useLocation, useNavigate } from 'react-router-dom';

const AdminLoginForm = () => {
    const { setUser } = useAuth();

    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || '/admin';
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const handleLogin = async () => {
        const loginData = {
            username,
            password,
        };

        const res = await axios.post('user/employee/login', loginData);
        if (res.status == HttpStatusCode.Ok) {
            // Login successfull
            const user: IAdminUser = {
                username,
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
        }
    };
    return (
        <Form fluid>
            <Form.Group>
                <Form.Control
                    value={username}
                    placeholder='Username'
                    name='username'
                    onChange={(e: string) => {
                        setUsername(e);
                    }}
                />
            </Form.Group>
            <Form.Group>
                <Form.Control
                    value={password}
                    placeholder='Password'
                    name='password'
                    type='password'
                    onChange={(e: string) => {
                        setPassword(e);
                    }}
                />
            </Form.Group>
            <Form.Group>
                <ButtonToolbar>
                    <Button appearance='primary' onClick={handleLogin}>
                        Sign in
                    </Button>
                </ButtonToolbar>
            </Form.Group>
        </Form>
    );
};

export default AdminLoginForm;
