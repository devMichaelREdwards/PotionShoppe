import { useState } from 'react';
import { Form } from 'rsuite';
import { ICustomerFilters } from '../../../types/IFilter';
import { CheckboxControl, TextControl } from '../../common/input/FormControl';
import { MagicWandIcon } from '../../common/image/Icon';
import ActionButton from '../../common/input/ActionButton';

interface IProps {
    filters: ICustomerFilters;
    setFilters: React.Dispatch<React.SetStateAction<ICustomerFilters>>;
    onClearCallback?: () => void;
}

const CustomerFilters = ({ filters, setFilters, onClearCallback }: IProps) => {
    const [firstName, setFirstName] = useState(filters.firstName ?? '');
    const [lastName, setLastName] = useState(filters.lastName ?? '');
    const [userName, setUserName] = useState(filters.lastName ?? '');
    const [active, setActive] = useState(false);
    const [banned, setBanned] = useState(false);
    const setFilterByKey = (key: keyof ICustomerFilters, value: string | number | boolean) => {
        setFilters({ ...filters, [key]: value });
        onClearCallback?.();
    };

    const clearFilters = () => {
        setFilters({
            firstName: '',
        });
        onClearCallback?.();
    };
    const clearFiltersClick = () => {
        setFirstName('');
        clearFilters();
    };
    return (
        <div className='filters'>
            <div className='filter-icon'>
                <MagicWandIcon />
                Filters
            </div>
            <Form className='filter-form'>
                <Form.Group className='filter-group'>
                    <TextControl
                        value={firstName}
                        label='First Name'
                        name='firstName'
                        onChange={(e: string) => {
                            setFirstName(e);
                            setFilterByKey('firstName', e);
                        }}
                    />
                    <TextControl
                        value={lastName}
                        label='Last Name'
                        name='lastName'
                        onChange={(e: string) => {
                            setLastName(e);
                            setFilterByKey('lastName', e);
                        }}
                    />
                    <TextControl
                        value={userName}
                        label='Username'
                        name='userName'
                        onChange={(e: string) => {
                            setUserName(e);
                            setFilterByKey('userName', e);
                        }}
                    />
                </Form.Group>
            </Form>
            <Form.Group className='filter-toggles'>
                <CheckboxControl
                    value={active}
                    label={'Active'}
                    name={'active'}
                    onChange={() => {
                        setActive(!active);
                        // Get statuses from filterLimits
                        setFilterByKey('active', !active);
                    }}
                />
                <CheckboxControl
                    value={banned}
                    label={'Banned'}
                    name={'banned'}
                    onChange={() => {
                        setBanned(!banned);
                        // Get statuses from filterLimits
                        setFilterByKey('banned', !banned);
                    }}
                />
            </Form.Group>
            <div className='clear-filters-button'>
                <ActionButton color={'red'} appearance={'ghost'} label={'Clear Filters'} action={clearFiltersClick} />
            </div>
        </div>
    );
};

export default CustomerFilters;
