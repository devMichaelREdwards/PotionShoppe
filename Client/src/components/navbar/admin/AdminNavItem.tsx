import { Link } from 'react-router-dom';
import { Nav } from 'rsuite';

interface IProps {
    title: string;
    route: string;
    eventKey: string;
    icon?: JSX.Element;
    setActive: (active: string) => void;
}

const AdminNavItem = ({ title, route, eventKey, icon, setActive }: IProps) => {
    return (
        <Nav.Item className='admin-nav-item' as={Link} to={route} icon={icon} eventKey={eventKey} onClick={() => setActive(eventKey)}>
            {title}
        </Nav.Item>
    );
};
export default AdminNavItem;
