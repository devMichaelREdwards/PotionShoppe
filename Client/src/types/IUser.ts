import { AxiosRequestConfig } from 'axios';

export interface IAdminUser {
    userName: string;
    token: string;
    loggedIn: boolean;
    authConfig: AxiosRequestConfig;
    roles: EmployeeRole[];
}

export type EmployeeRole = 'Employee' | 'Owner';
