import CustomerIconColor from '/assets/icon/color/Customer_Icon.svg';
import CustomerIconGrey from '/assets/icon/greyscale/Customer_Icon.svg';
import EmployeeIconColor from '/assets/icon/color/Employee_Icon.svg';
import EmployeeIconGrey from '/assets/icon/greyscale/Employee_Icon.svg';
import PotionIconColor from '/assets/icon/color/Potion_Icon.svg';
import PotionIconGrey from '/assets/icon/greyscale/Potion_Icon.svg';
import EffectIconColor from '/assets/icon/color/Effect_Icon.svg';
import EffectIconGrey from '/assets/icon/greyscale/Effect_Icon.svg';
import IngredientIconColor from '/assets/icon/color/Ingredient_Icon.svg';
import IngredientIconGrey from '/assets/icon/greyscale/Ingredient_Icon.svg';
import OrderIconColor from '/assets/icon/color/Order_Icon.svg';
import OrderIconGrey from '/assets/icon/greyscale/Order_Icon.svg';
import ReceiptIconColor from '/assets/icon/color/Receipt_Icon.svg';
import ReceiptIconGrey from '/assets/icon/greyscale/Receipt_Icon.svg';
import MagicWand from '/assets/icon/Magic_Wand.svg';
import Sort from '/assets/icon/Sort.svg';
import SortUp from '/assets/icon/Sort_Up.svg';
import SortDown from '/assets/icon/Sort_Down.svg';
import { SortOrder } from '../listing/Listing';

interface IIcon {
    active?: boolean;
}

export const CustomerIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={CustomerIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={CustomerIconColor} />
        </div>
    );
};

export const EmployeeIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={EmployeeIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={EmployeeIconColor} />
        </div>
    );
};

export const PotionIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={PotionIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={PotionIconColor} />
        </div>
    );
};

export const EffectIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={EffectIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={EffectIconColor} />
        </div>
    );
};

export const IngredientIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={IngredientIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={IngredientIconColor} />
        </div>
    );
};

export const OrderIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={OrderIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={OrderIconColor} />
        </div>
    );
};

export const ReceiptIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active ? 'hidden' : ''}`} src={ReceiptIconGrey} />
            <img className={`color-image ${active ? 'active' : 'hidden'}`} src={ReceiptIconColor} />
        </div>
    );
};

export const MagicWandIcon = () => {
    return (
        <div className='icon'>
            <img src={MagicWand} />
        </div>
    );
};

interface ISortIcon {
    sort: SortOrder;
}

export const SortIcon = ({ sort }: ISortIcon) => {
    if (sort === SortOrder.ascending) {
        return (
            <div className='icon sort-icon'>
                <img src={SortUp} />
            </div>
        );
    }

    if (sort === SortOrder.descending) {
        return (
            <div className='icon sort-icon'>
                <img src={SortDown} />
            </div>
        );
    }

    return (
        <div className='icon sort-icon'>
            <img src={Sort} />
        </div>
    );
};
