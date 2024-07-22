import { useState } from 'react';
import { Form } from 'rsuite';
import { IAccountFilters } from '../../../types/IFilter';
import { CheckboxControl, TagSearchInput, TextControl } from '../../common/input/FormControl';
import { ICollectionObject } from '../../../types/IListing';
import FilterTitle from './FilterTitle';
import ClearFilterButton from './ClearFilterButton';

interface IProps {
    filters: IAccountFilters;
    setFilters: React.Dispatch<React.SetStateAction<IAccountFilters>>;
    onClearCallback?: () => void;
}

const EmployeeFilters = ({ filters, setFilters, onClearCallback }: IProps) => {
    const [positionQuery, setPositionQuery] = useState('');
    const [positions, setPositions] = useState<ICollectionObject[]>([]);
    const [firstName, setFirstName] = useState(filters.firstName ?? '');
    const [lastName, setLastName] = useState(filters.lastName ?? '');
    const [userName, setUserName] = useState(filters.lastName ?? '');
    const [email, setEmail] = useState(filters.lastName ?? '');
    const [active, setActive] = useState(false);
    const [banned, setBanned] = useState(false);
    const setFilterByKey = (key: keyof IAccountFilters, value: string | number | boolean) => {
        setFilters({ ...filters, [key]: value });
        onClearCallback?.();
    };
    const addPosition = (position: ICollectionObject) => {
        const newPositions = [...positions, position];
        setPositions(newPositions);
        setFilters({ ...filters, positions: newPositions.map((e) => e.id ?? 0) });
        onClearCallback?.();
    };

    const removePosition = (id: number) => {
        const newPositions = [...positions.filter((e) => e.id !== id)];
        setPositions(newPositions);
        setFilters({ ...filters, positions: newPositions.map((e) => e.id ?? 0) });
        onClearCallback?.();
    };

    const clearFilters = () => {
        setFilters({
            firstName: '',
            lastName: '',
            userName: '',
            email: '',
            active: false,
            banned: false,
            positions: [],
        });
        onClearCallback?.();
    };
    const clearFiltersClick = () => {
        setFirstName('');
        setLastName('');
        setUserName('');
        setEmail('');
        setActive(false);
        setBanned(false);
        setPositions([]);
        setPositionQuery('');
        clearFilters();
    };
    return (
        <div className='filters'>
            <FilterTitle />
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
                </Form.Group>
                <Form.Group className='filter-group'>
                    <TextControl
                        value={userName}
                        label='Username'
                        name='userName'
                        onChange={(e: string) => {
                            setUserName(e);
                            setFilterByKey('userName', e);
                        }}
                    />
                    <TextControl
                        value={email}
                        label='Email'
                        name='email'
                        onChange={(e: string) => {
                            setEmail(e);
                            setFilterByKey('email', e);
                        }}
                    />
                    <TagSearchInput
                        value={positionQuery}
                        label='Position'
                        route='employeeposition'
                        tags={positions}
                        idKey='employeePositionId'
                        dataKey='title'
                        addTag={addPosition}
                        removeTag={removePosition}
                        setValue={(newValue) => setPositionQuery(newValue)}
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
                    label={'Terminated'}
                    name={'banned'}
                    onChange={() => {
                        setBanned(!banned);
                        // Get statuses from filterLimits
                        setFilterByKey('banned', !banned);
                    }}
                />
            </Form.Group>
            <ClearFilterButton clearFiltersClick={clearFiltersClick} />
        </div>
    );
};

export default EmployeeFilters;
