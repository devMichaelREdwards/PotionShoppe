import { TypeAttributes } from 'rsuite/esm/@types/common';

export interface IListingColumn {
    align: 'left' | 'center' | 'right';
    label: string;
    dataKey: string;
    colspan: number;
    component?: (data: unknown) => JSX.Element;
}

export interface IActionButton {
    appearance: TypeAttributes.Appearance;
    label?: string;
    color?: TypeAttributes.Color;
    icon?: JSX.Element;
    argKey?: string;
    [arg: string]: unknown;
    action: (arg: unknown) => void;
}

export interface ICollectionObject {
    id?: number;
    title: string;
    color?: string;
}
