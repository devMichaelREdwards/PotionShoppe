import useBreadcrumbs from '../../../hooks/useBreadcrumbs';
import Crumb from './Crumb';

interface IProps {
    separator: string | JSX.Element;
}

const Breadcrumbs = ({ separator }: IProps) => {
    const breadcrumbs = useBreadcrumbs();

    return (
        <>
            {breadcrumbs.map((crumb, i) => {
                return (
                    <>
                        <Crumb {...crumb} />
                        {i != breadcrumbs.length - 1 && <>{separator}</>}
                    </>
                );
            })}
        </>
    );
};

export default Breadcrumbs;
