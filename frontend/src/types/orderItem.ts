import { ProductType } from "./product";

export interface OrderItemProductType extends ProductType{
    quantity: number
}


export type AddressTypes = {
  address: string;
  city: string;
  postalCode: string;
  country: string;
};
