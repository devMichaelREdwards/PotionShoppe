import CustomerIconColor from '../../../../public/assets/icon/color/Customer_Icon.svg';
import CustomerIconGrey from '../../../../public/assets/icon/greyscale/Customer_Icon.svg';
import EmployeeIconColor from '../../../../public/assets/icon/color/Employee_Icon.svg';
import EmployeeIconGrey from '../../../../public/assets/icon/greyscale/Employee_Icon.svg';
import PotionIconColor from '../../../../public/assets/icon/color/Potion_Icon.svg';
import PotionIconGrey from '../../../../public/assets/icon/greyscale/Potion_Icon.svg';
import EffectIconColor from '../../../../public/assets/icon/color/Effect_Icon.svg';
import EffectIconGrey from '../../../../public/assets/icon/greyscale/Effect_Icon.svg';
import IngredientIconColor from '../../../../public/assets/icon/color/Ingredient_Icon.svg';
import IngredientIconGrey from '../../../../public/assets/icon/greyscale/Ingredient_Icon.svg';
import OrderIconColor from '../../../../public/assets/icon/color/Order_Icon.svg';
import OrderIconGrey from '../../../../public/assets/icon/greyscale/Order_Icon.svg';
import ReceiptIconColor from '../../../../public/assets/icon/color/Receipt_Icon.svg';
import ReceiptIconGrey from '../../../../public/assets/icon/greyscale/Receipt_Icon.svg';

interface IIcon {
    active?: boolean;
}

export const CustomerIcon = ({ active }: IIcon) => {
    const src = active ? CustomerIconColor : CustomerIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};

export const EmployeeIcon = ({ active }: IIcon) => {
    const src = active ? EmployeeIconColor : EmployeeIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};

export const PotionIcon = ({ active }: IIcon) => {
    const src = active ? PotionIconColor : PotionIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};

export const EffectIcon = ({ active }: IIcon) => {
    const src = active ? EffectIconColor : EffectIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};

export const IngredientIcon = ({ active }: IIcon) => {
    const src = active ? IngredientIconColor : IngredientIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};

export const OrderIcon = ({ active }: IIcon) => {
    const src = active ? OrderIconColor : OrderIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};

export const ReceiptIcon = ({ active }: IIcon) => {
    const src = active ? ReceiptIconColor : ReceiptIconGrey;
    return (
        <div className='icon'>
            <img src={src} />
        </div>
    );
};
