import { Link } from 'react-router-dom';
import { Button } from 'rsuite';

const AdminDashboardPage = () => {
    return (
        <>
            Employee Dashboard
            <p>
                Test
                <Link to='other'>
                    <Button appearance='primary'>Other Page</Button>
                </Link>
            </p>
        </>
    );
};

export default AdminDashboardPage;
