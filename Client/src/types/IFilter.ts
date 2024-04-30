export interface IEffectFilters {
    name?: string;
    vmin?: number;
    vmax?: number;
    dmin?: number;
    dmax?: number;
}

export interface IIngredientFilters {
    name?: string;
    categories?: number[];
    effects?: number[];
    cmin?: number;
    cmax?: number;
    pmin?: number;
    pmax?: number;
    instock?: boolean;
}

export interface IPotionFilters {
    name?: string;
    effects?: number[];
    cmin?: number;
    cmax?: number;
    pmin?: number;
    pmax?: number;
    instock?: boolean;
}
