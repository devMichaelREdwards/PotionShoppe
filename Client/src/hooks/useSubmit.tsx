import { Message, useToaster } from 'rsuite';
import axios from '../api/axios';
import { IPostData } from '../types/IData';
import useAuth from './useAuth';
import { useState } from 'react';

interface IErrorState {
    [key: string]: string;
}

export const useSubmit = (route: string, successMessage: string, errorMessage: string) => {
    const toaster = useToaster();
    const { user } = useAuth();
    const [submitting, setSubmitting] = useState(false);
    const [errors, setErrors] = useState<IErrorState>();
    let request;

    const submitForm = async (data: IPostData, successCallback?: () => void, errorCallback?: () => void) => {
        if (data.effectId && (data.effectId as number) > 0) {
            request = axios.put(route, data, user?.authConfig);
        } else {
            request = axios.post(route, data, user?.authConfig);
        }

        await request
            .then(() => {
                toaster.push(<Message type='success'>{successMessage}</Message>, { duration: 5000 });
                successCallback?.();
            })
            .catch((error) => {
                toaster.push(<Message type='error'>{errorMessage}</Message>, { duration: 5000 });
                setErrors(error.response.data.errors);
                errorCallback?.();
            })
            .finally(() => {
                setSubmitting(false);
            });
    };

    return { submitting, errors, submitForm };
};
