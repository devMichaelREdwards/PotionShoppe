import AdminRoutes from './components/routes/AdminRoutes';

const App = () => {
    // At some point, replace /admin with something loaded from an environment file
    return (
        <>
            <AdminRoutes />
            {/*<HomeRoutes />*/}
        </>
    );
};

export default App;
