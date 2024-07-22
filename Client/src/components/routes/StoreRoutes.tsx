import { Route, Routes } from 'react-router-dom';
import { AuthProvider } from '../../context/AuthContext';

const StoreRoutes = () => {
    return (
        <AuthProvider>
            <Routes>
                <Route
                    path='/'
                    element={
                        <>
                            <a href='https://www.flaticon.com/' title='icons'>
                                Icons created by Freepik - Flaticon
                            </a>
                        </>
                    }
                />
            </Routes>
        </AuthProvider>
    );
};

export default StoreRoutes;
