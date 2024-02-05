import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';
import './scss/index.scss';
import { BrowserRouter } from 'react-router-dom';
import { CustomProvider } from 'rsuite';

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <BrowserRouter>
            <CustomProvider>
                <App />
            </CustomProvider>
        </BrowserRouter>
    </React.StrictMode>
);
