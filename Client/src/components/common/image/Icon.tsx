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
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={CustomerIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={CustomerIconColor} />
        </div>
    );
};

export const EmployeeIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={EmployeeIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={EmployeeIconColor} />
        </div>
    );
};

export const PotionIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={PotionIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={PotionIconColor} />
        </div>
    );
};

export const EffectIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={EffectIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={EffectIconColor} />
        </div>
    );
};

export const IngredientIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={IngredientIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={IngredientIconColor} />
        </div>
    );
};

export const OrderIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={OrderIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={OrderIconColor} />
        </div>
    );
};

export const ReceiptIcon = ({ active }: IIcon) => {
    return (
        <div className='icon color-icon'>
            <img className={`greyscale-image ${active && 'hidden'}`} src={ReceiptIconGrey} />
            <img className={`color-image ${!active && 'hidden'} ${active && 'active'}`} src={ReceiptIconColor} />
        </div>
    );
};
