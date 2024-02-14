import { useLocation } from 'react-router-dom';

export interface IBreadcrumb {
    src: string;
    name: string;
}

const useBreadcrumbs = () => {
    const location = useLocation();
    console.log(location.pathname);
    const route = location.pathname.substring(1).split('/');

    const breadcrumbs: IBreadcrumb[] = [];

    route.forEach((crumb) => {
        if (crumb == 'admin') {
            breadcrumbs.push({
                src: '/admin',
                name: 'Home',
            });
        } else if (crumb == 'an id') {
            // Do nothing
        } else {
            breadcrumbs.push({
                src: crumb,
                name: crumb.charAt(0).toUpperCase() + crumb.substring(1),
            });
        }
    });

    return breadcrumbs;
};

export default useBreadcrumbs;
