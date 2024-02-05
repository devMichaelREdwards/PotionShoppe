import './App.css';
import { Link, Route, Routes } from 'react-router-dom';
import HomePage from './components/pages/store/HomePage';
import EmployeeLoginPage from './components/pages/owner/EmployeeLoginPage';

const App = () => {
    // At some point, replace /admin with something loaded from an environment file
    return (
        <>
            <nav>
                <ul>
                    <li>
                        <Link to='/'>Home</Link>
                    </li>
                    <li>
                        <   Link to='/admin'>Admin</>
                    </li>
                </ul>
            </nav>
            <Routes>
                <Route path='/' element={<HomePage />} />
                <Route path='/admin' element={<EmployeeLoginPage />} />
            </Routes>
        </>
    );
};

export default App;
