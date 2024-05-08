import axios from 'axios';

export const API_URL = 'https://localhost:7211/api';

export default axios.create({
    baseURL: API_URL,
});
