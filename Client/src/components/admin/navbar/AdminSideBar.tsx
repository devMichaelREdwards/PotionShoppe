import { Sidebar, Sidenav, Nav } from 'rsuite';
import AdminNavItem from './AdminNavItem';
import { Link, useNavigate } from 'react-router-dom';
import { CustomerIcon, EffectIcon, EmployeeIcon, IngredientIcon, OrderIcon, ReceiptIcon, PotionIcon } from '../../common/image/Icon';
import { useState } from 'react';
import CopyrightText from '../../common/information/CopyrightText';
import AdminNavButton from './AdminNavButton';
import axios from '../../../api/axios';
import useAuth from '../../../hooks/useAuth';

const headerStyles = {
    // Put this into actual CSS when you do styling
    padding: 18,
    fontSize: 16,
    height: 56,
    color: ' #000',
    whiteSpace: 'nowrap',
    overflow: 'hidden',
    textAlign: 'center' as const,
};

const AdminDashboardLink = () => {
    return (
        <div style={headerStyles}>
            <Link to='/admin'>
                <span>Potion Shoppe</span>
            </Link>
        </div>
    );
};

const AdminSideBar = () => {
    const [active, setActive] = useState('');
    const { user, setUser } = useAuth();
    const navigate = useNavigate();
    const logout = async (eventKey?: string) => {
        await axios.post('user/employee/logout', { username: user?.userName, key: eventKey }).then(() => {
            setUser(undefined);
            navigate('login', { replace: true });
        });
    };
    return (
        <Sidebar className='admin-sidebar'>
            <Sidenav>
                <Sidenav.Header>
                    <AdminDashboardLink />
                </Sidenav.Header>
                <Sidenav.Body>
                    <Nav>
                        <Nav.Menu className='admin-nav-menu' eventKey='1' title='Users'>
                            <AdminNavItem
                                title='Customers'
                                route='customers'
                                eventKey='1-1'
                                icon={<CustomerIcon active={active === '1-1'} />}
                                setActive={setActive}
                            />
                            <AdminNavItem
                                title='Employees'
                                route='employees'
                                eventKey='1-2'
                                icon={<EmployeeIcon active={active === '1-2'} />}
                                setActive={setActive}
                            />
                        </Nav.Menu>
                        <Nav.Menu className='admin-nav-menu' eventKey='2' title='Inventory'>
                            <AdminNavItem
                                title='Potions'
                                route='potions'
                                eventKey='2-1'
                                icon={<PotionIcon active={active === '2-1'} />}
                                setActive={setActive}
                            />
                            <AdminNavItem
                                title='Ingredients'
                                route='ingredients'
                                eventKey='2-2'
                                icon={<IngredientIcon active={active === '2-2'} />}
                                setActive={setActive}
                            />
                            <AdminNavItem
                                title='Effects'
                                route='effects'
                                eventKey='2-3'
                                icon={<EffectIcon active={active === '2-3'} />}
                                setActive={setActive}
                            />
                        </Nav.Menu>
                        <Nav.Menu className='admin-nav-menu' eventKey='3' title='Orders'>
                            <AdminNavItem
                                title='Orders'
                                route='orders'
                                eventKey='3-1'
                                icon={<OrderIcon active={active === '3-1'} />}
                                setActive={setActive}
                            />
                            <AdminNavItem
                                title='Receipts'
                                route='receipts'
                                eventKey='3-2'
                                icon={<ReceiptIcon active={active === '3-2'} />}
                                setActive={setActive}
                            />
                        </Nav.Menu>
                    </Nav>
                </Sidenav.Body>
            </Sidenav>
            <div className='admin-bottom-nav'>
                <AdminNavButton title={'My Account'} action={logout} />
                <AdminNavButton title={'Logout'} action={logout} />
                <div className='admin-copyright'>
                    <CopyrightText />
                </div>
            </div>
        </Sidebar>
    );
};

export default AdminSideBar;
