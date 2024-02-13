import { useState } from 'react';
import { Sidebar, Sidenav, Nav } from 'rsuite';
import AdminNavItem from './AdminNavItem';
import { Link } from 'react-router-dom';

const headerStyles = {
    // Put this into actual CSS when you do styling
    padding: 18,
    fontSize: 16,
    height: 56,
    background: '#FFF',
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
    const [expand, setExpand] = useState(true);
    return (
        <Sidebar style={{ display: 'flex', flexDirection: 'column' }} width={expand ? 260 : 56} collapsible>
            <Sidenav.Header>
                <AdminDashboardLink />
            </Sidenav.Header>
            <Sidenav expanded={expand} appearance='subtle'>
                <Sidenav.Body>
                    <Nav>
                        <Nav.Menu eventKey='1' title='Users'>
                            <AdminNavItem title='Customers' route='customers' eventKey='1-1' />
                            <AdminNavItem title='Employees' route='employees' eventKey='1-2' />
                        </Nav.Menu>
                        <Nav.Menu eventKey='2' title='Inventory'>
                            <AdminNavItem title='Potions' route='potions' eventKey='2-1' />
                            <AdminNavItem title='Ingredients' route='ingredients' eventKey='2-2' />
                            <AdminNavItem title='Effects' route='effects' eventKey='2-3' />
                        </Nav.Menu>
                        <Nav.Menu eventKey='3' title='Orders'>
                            <AdminNavItem title='Orders' route='orders' eventKey='3-1' />
                            <AdminNavItem title='Receipts' route='receipts' eventKey='3-2' />
                        </Nav.Menu>
                    </Nav>
                </Sidenav.Body>
                <Sidenav.Toggle onToggle={(expanded) => setExpand(expanded)} />
            </Sidenav>
        </Sidebar>
    );
};

export default AdminSideBar;
