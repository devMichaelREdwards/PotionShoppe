import { TypeAttributes } from 'rsuite/esm/@types/common';
import { ActionButtonColor } from './UI';

export interface IListingColumn {
    align: 'left' | 'center' | 'right';
    label: string;
    dataKey: string;
    colspan: number;
    sortable?: boolean;
    component?: (data: unknown) => JSX.Element;
}

export interface IActionButton {
    appearance?: TypeAttributes.Appearance;
    label?: string;
    color?: ActionButtonColor;
    icon?: JSX.Element;
    argKey?: string;
    currentValue?: unknown;
    isToggle?: boolean;
    [arg: string]: unknown;
    action?: (arg: unknown) => void;
    refresh?: () => void;
}

export interface ICollectionObject {
    id?: number;
    title: string;
    color?: string;
}
