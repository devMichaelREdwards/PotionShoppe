import axios from 'axios';
import { useEffect, useState } from 'react';
import useAuth from './useAuth';
import { IData } from '../types/IData';
import { API_URL } from '../api/api';

export const useData = (source: string) => {
    const [data, setData] = useState<IData[]>([]);
    const [loading, setLoading] = useState(true);
    const [draw, setDraw] = useState(0);
    const [error, setError] = useState('');
    const { user } = useAuth();

    useEffect(() => {
        const getData = async () => {
            if (source.length) {
                try {
                    const result = await axios.get(`${API_URL}/${source}`, user?.authConfig);
                    setData(result.data);
                } catch (e) {
                    setError('Unknown Error occurred');
                }
            }

            setLoading(false);
        };
        getData();
    }, [source, draw, user?.authConfig]);

    const refresh = () => {
        setDraw(draw + 1);
    };

    return { data, draw, loading, error, refresh, setLoading };
};

export const useID = (source: string) => {
    const [data, setData] = useState<IData>();
    const [loading, setLoading] = useState(true);
    const [draw, setDraw] = useState(0);
    const [error, setError] = useState('');
    const { user } = useAuth();

    useEffect(() => {
        const getData = async () => {
            if (source.length) {
                try {
                    const result = await axios.get(`${API_URL}/${source}`, user?.authConfig);
                    setData(result.data);
                } catch (e) {
                    setError('Unknown Error occurred');
                }
            }

            setLoading(false);
        };
        getData();
    }, [source, draw, user?.authConfig]);

    const refresh = () => {
        setDraw(draw + 1);
    };

    return { data, draw, loading, error, refresh, setLoading };
};
