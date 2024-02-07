import { AxiosRequestConfig } from 'axios';

export interface IAdminUser {
    username: string;
    token: string;
    loggedIn: boolean;
    authConfig: AxiosRequestConfig;
    roles: EmployeeRole[];
}

export type EmployeeRole = 'Employee' | 'Owner';
