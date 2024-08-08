import { TypeAttributes } from 'rsuite/esm/@types/common';
import { ActionButtonColor } from './UI';

export interface IListingColumn {
    align: 'left' | 'center' | 'right';
    label: string;
    dataKey: string;
    colspan: number;
    sortable?: boolean;
    retrieveAllData?: boolean;
    component?: (data: unknown, refresh?: () => void) => JSX.Element;
}

export interface IActionButton {
    appearance?: TypeAttributes.Appearance;
    label?: string;
    color?: ActionButtonColor;
    icon?: JSX.Element;
    argKey?: string;
    currentValue?: unknown;
    isToggle?: boolean;
    tooltip?: string;
    placement?: TypeAttributes.Placement;
    [arg: string]: unknown;
    action?: (arg: unknown) => void;
    refresh?: () => void;
    noRefresh?: boolean;
    disabled?: boolean;
}

export interface ICollectionObject {
    id?: number;
    title: string;
    color?: string;
}
