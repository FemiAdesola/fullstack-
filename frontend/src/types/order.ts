import { OrderItemProductType } from './orderItem';
import { ProductType } from './product';

export interface OrderTypes  {
 id: number | string;
  user: string;
  shippingAddress: {
    address: string;
    city: string;
    postalCode: string;
    country: string;
  };
  orderItems: ProductType[];
  totalPrice: number;
  isPaid: boolean;
    createdAt: Date;
};

export interface OrderReducer{
  orderItems: OrderItemProductType[];
  orders: OrderTypes[]
  totalPrice: number;
}