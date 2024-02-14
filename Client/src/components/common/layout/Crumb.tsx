import { Link } from 'react-router-dom';
import { IBreadcrumb } from '../../../hooks/useBreadcrumbs';

const Crumb = ({ src, name }: IBreadcrumb) => {
    return <Link to={src}>{name}</Link>;
};

export default Crumb;
