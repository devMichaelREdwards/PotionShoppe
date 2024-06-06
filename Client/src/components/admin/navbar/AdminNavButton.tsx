import { Button } from 'rsuite';

interface IProps {
    title: string;
    icon?: JSX.Element;
    action: () => void;
}

const AdminNavButton = ({ title, icon, action }: IProps) => {
    return (
        <Button className='admin-nav-button' as={Button} icon={icon} onClick={() => action()}>
            {title}
        </Button>
    );
};
export default AdminNavButton;
