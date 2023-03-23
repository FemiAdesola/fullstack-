import { createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import { AxiosError } from "axios";

import { OrderReducer} from '../../types/order';
import { getOrderById, getOrdersList, getUserOrder } from "../method/orderMethod";

const initialState: OrderReducer = {
  orders: [],
  totalPrice: 0,
  orderItems: [],
}

export const getOrdersPrice = createEntityAdapter<OrderReducer>({
  selectId: (state) =>
    state.orders.reduce((acc, order) => acc + order.totalPrice, 0),
});

const orderListSlice = createSlice({
  name: 'ordersList',
  initialState: initialState,
    reducers: {
    
  },
    extraReducers: (builder) => {
       builder.addCase(getOrdersList.fulfilled, (state, action) => {
      if (action.payload instanceof AxiosError) {
                return state
            } else if (!action.payload) {
                return state
        }
        return action.payload
        })
        .addCase(getOrdersList.pending, (state, action) => {
            return state
        })
        .addCase(getOrdersList.rejected, (state, action) => {
            return state
        })
        .addCase(getOrderById.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state
            } else {
               state.orders = action.payload
            }
            })
        .addCase(getUserOrder.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          return state
        } else {
          state.orders = action.payload
        }
    })
  },
});

const orderReducer = orderListSlice.reducer
export default orderReducer
