import axios from '../api/axios';
import { IAdminUser } from '../types/IUser';

export const authenticateEmployee = async (user: IAdminUser) => {
    const res = await axios.post('user/employee/authenticate', {}, user.authConfig);
    return res?.data ?? false;
};
