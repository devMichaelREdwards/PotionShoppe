import { Header } from 'rsuite';

interface IProps {
    title: string;
}

const ModalHeader = ({ title }: IProps) => {
    return (
        <Header className='modal-header'>
            <h2>{title}</h2>
        </Header>
    );
};
export default ModalHeader;
