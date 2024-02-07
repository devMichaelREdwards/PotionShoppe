import { createContext, useState } from 'react';
import { IAdminUser } from '../types/IUser';

interface IAuthContext {
    user: IAdminUser | undefined;
    setUser: React.Dispatch<React.SetStateAction<IAdminUser | undefined>>;
}

const AuthContext = createContext<IAuthContext>({} as IAuthContext);

interface IProps {
    children: string | JSX.Element | JSX.Element[];
}

export const AuthProvider = ({ children }: IProps) => {
    const [user, setUser] = useState<IAdminUser>();

    return <AuthContext.Provider value={{ user, setUser }}>{children}</AuthContext.Provider>;
};

export default AuthContext;
