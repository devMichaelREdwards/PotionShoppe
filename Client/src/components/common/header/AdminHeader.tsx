import { Header } from 'rsuite';
import Breadcrumbs from '../layout/Breadcrumbs';

interface IProps {
    title: string;
}

const AdminHeader = ({ title }: IProps) => {
    return (
        <Header className='admin-header'>
            <h2>{title}</h2>
            <Breadcrumbs separator={'>'} />
        </Header>
    );
};
export default AdminHeader;
