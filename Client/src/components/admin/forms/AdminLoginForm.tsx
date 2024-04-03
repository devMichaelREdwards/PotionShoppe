import { useState } from 'react';
import axios from '../../../api/axios';
import { HttpStatusCode } from 'axios';
import { IAdminUser } from '../../../types/IUser';
import { Button, ButtonToolbar, Form } from 'rsuite';
import useAuth from '../../../hooks/useAuth';
import { useLocation, useNavigate } from 'react-router-dom';
import { TextControl, PasswordControl } from '../../common/input/FormControl';

const AdminLoginForm = () => {
    const { setUser } = useAuth();
    const navigate = useNavigate();
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
                // Login successfull
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
                console.log(error.response.data);
            });

        setLoading(false);
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
                    {/*<ImageButton className='admin-login-button' src='/assets/employee/Burned_Parchment.png' onClick={handleLogin} loading={loading} />*/}
                    <Button appearance='primary' onClick={handleLogin} loading={loading}>
                        <div className={`image-button admin-login-button`}>
                            <img src={'/assets/employee/Burned_Parchment.png'} />
                            {!loading && <div className='image-button-text'>Sign In</div>}
                        </div>
                    </Button>
                </ButtonToolbar>
            </Form.Group>
        </Form>
    );
};

interface IImageButton {
    src: string;
    className?: string;
    loading?: boolean;
    onClick: () => Promise<void>;
}

const ImageButton = ({ src, className, loading, onClick }: IImageButton) => {
    return (
        <Button appearance='primary' onClick={onClick} loading={loading}>
            <div className={`image-button ${className}`}>
                <img src={src} />
                {!loading && <div className='image-button-text'>Sign In</div>}
            </div>
        </Button>
    );
};

export default AdminLoginForm;
