import axios from 'axios';
import { useEffect, useState } from 'react';

export interface IData {
    [key: string]: unknown;
}

export const useData = (source: string) => {
    const [data, setData] = useState();
    const [loading, setLoading] = useState(true);
    const [draw, setDraw] = useState(0);

    useEffect(() => {
        const getData = async () => {
            if (source.length) {
                const result = await axios.get(`https://localhost:7211/api/${source}`);
                setData(result.data);
            }

            setLoading(false);
        };
        getData();
    }, [source, draw]);

    const refresh = () => {
        setDraw((prevDraw) => {
            return prevDraw + 1;
        });
    };

    return { data, loading, refresh };
};
