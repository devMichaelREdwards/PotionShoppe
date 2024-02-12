import { Link } from 'react-router-dom';
import { Nav } from 'rsuite';
import setTitle from '../../../helpers/setTitle';

interface IProps {
    title: string;
    route: string;
    eventKey: string;
    icon?: JSX.Element;
}

const AdminNavItem = ({ title, route, eventKey, icon }: IProps) => {
    return (
        <Nav.Item
            as={Link}
            to={route}
            icon={icon}
            eventKey={eventKey}
            onClick={() => {
                setTitle(title);
            }}
        >
            {title}
        </Nav.Item>
    );
};
export default AdminNavItem;
