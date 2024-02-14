import { Link } from 'react-router-dom';
import { IBreadcrumb } from '../../../hooks/useBreadcrumbs';

const Crumb = ({ src, name, active }: IBreadcrumb) => {
    return (
        <Link className={`crumb${active ? ' active-crumb' : ''}`} to={src}>
            {name}
        </Link>
    );
};

export default Crumb;
