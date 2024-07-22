/* eslint-disable @typescript-eslint/ban-ts-comment */
// @ts-nocheck - may need to be at the start of file
export const debounce = (cb, delay = 100) => {
    let timeout;

    return (...args) => {
        clearTimeout(timeout);
        timeout = setTimeout(() => {
            cb(...args);
        }, delay);
    };
};

export const throttle = (cb, delay = 100) => {
    let shouldWait = false;

    return (...args) => {
        if (shouldWait) return;

        cb(...args);
        shouldWait = true;

        setTimeout(() => {
            shouldWait = false;
        }, delay);
    };
};
