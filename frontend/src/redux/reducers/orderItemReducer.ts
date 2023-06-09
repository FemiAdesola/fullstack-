import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AddressTypes, OrderItemProductType } from "../../types/orderItem";


export interface OrderItemSliceState {
  orderItems: OrderItemProductType[];
  shippingAddress: AddressTypes | null;
}
const initialState: OrderItemSliceState = {
  orderItems: [],
  shippingAddress: null,
};

export const orderItemSlice = createSlice({
  name: 'orderItem',
  initialState: initialState,
  reducers: {
    addToOrderItem: (state: OrderItemSliceState, action: PayloadAction<OrderItemProductType>) => {
      const product = action.payload;
      const existItem = state.orderItems.find(
        (orderItem) => orderItem.id === product.id
      );
      if (existItem) {
        state.orderItems = state.orderItems.map((orderItem) =>
          orderItem.id === product.id ? { ...product, quantity: orderItem.quantity + 1 } : orderItem
        );
      } else {
        state.orderItems = [...state.orderItems, { ...product, quantity: 1 }];
      }
    },
    removeFromOrderItem: (state: OrderItemSliceState, action: PayloadAction<OrderItemProductType>) => {
      const product = action.payload;
      const existItem = state.orderItems.find(
        (orderItem) => orderItem.id === product.id
      );

      if (existItem && existItem.quantity === 1) {
        state.orderItems = state.orderItems.filter(
          (orderItem) => orderItem.id !== product.id
        );
      } else {
        state.orderItems = state.orderItems.map((orderItem) =>
          orderItem.id === product.id ? { ...product, quantity: orderItem.quantity - 1 } : orderItem
        );
      }
    },
    saveAddress: (
      state: OrderItemSliceState,
      action: PayloadAction<AddressTypes>
    ) => {
      state.shippingAddress = action.payload;
    },
    reset: (state) => {
      state.orderItems = [];
      state.shippingAddress = null;
    }
  },
});

const orderItemReducer= orderItemSlice.reducer
export const { addToOrderItem, removeFromOrderItem, reset, saveAddress} = orderItemSlice.actions;
export default orderItemReducer