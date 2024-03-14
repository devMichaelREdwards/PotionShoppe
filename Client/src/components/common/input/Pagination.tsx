import { useState } from 'react';
import { Input, InputGroup } from 'rsuite';

interface IProps {
    page: number;
    limit: number;
    onPageChange: (page: number) => void;
    onLimitChange: (limit: number) => void;
}

const Pagination = ({ page, limit, onPageChange, onLimitChange }: IProps) => {
    const [pageInput, setPage] = useState(page.toString());
    const [limitInput, setLimit] = useState(limit.toString());

    const changePage = (newPage: string) => {
        const pageNumber = parseInt(newPage);
        if (pageNumber) onPageChange(pageNumber);
        else {
            onPageChange(1);
        }
    };

    const changeLimit = (newLimit: string) => {
        const limitNumber = parseInt(newLimit);
        if (limitNumber) onLimitChange(limitNumber);
        else {
            onLimitChange(1);
        }
    };

    return (
        <InputGroup className='pagination'>
            <div className='page-selection'>
                <div className='label'>Page</div>
                <button
                    onClick={() => {
                        const newPage = page - 1;
                        onPageChange(newPage);
                        setPage(newPage.toString());
                    }}
                >
                    {'<'}
                </button>
                <Input
                    name={'page'}
                    className='form-control-input'
                    value={pageInput}
                    onChange={(newPage) => {
                        setPage(newPage);
                    }}
                    onKeyDown={(event) => {
                        if (event.key == 'Enter') {
                            changePage(event.currentTarget.value);
                            return;
                        }
                    }}
                    onBlur={(event) => {
                        changePage(event.currentTarget.value);
                    }}
                />
                <button
                    onClick={() => {
                        const newPage = page + 1;
                        onPageChange(newPage);
                        setPage(newPage.toString());
                    }}
                >
                    {'>'}
                </button>
            </div>
            <div className='limit-selection'>
                <div className='label'>Limit</div>
                <Input
                    name={'limit'}
                    className='form-control-input'
                    value={limitInput}
                    onChange={(newLimit) => {
                        setLimit(newLimit);
                    }}
                    onKeyDown={(event) => {
                        if (event.key == 'Enter') {
                            changeLimit(event.currentTarget.value);
                            return;
                        }
                    }}
                    onBlur={(event) => {
                        changeLimit(event.currentTarget.value);
                    }}
                />
            </div>
        </InputGroup>
    );
};

export default Pagination;
