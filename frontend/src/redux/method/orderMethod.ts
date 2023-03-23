import { createAsyncThunk } from "@reduxjs/toolkit";
import { AxiosError } from "axios";
import axiosInstance from "../../common/axiosIntsance";

import { OrderTypes } from "../../types/order";

export const getOrdersList = createAsyncThunk(
    'ordersList',
    async () => {
    try {
        const { data } = await axiosInstance.get('/orders');
        return data;
    } catch (err) {
         const error = err as AxiosError
        if (error.response) {
                return(error.response.data)
            }else if (error.request) {
                return(`Error from request: ${error.message}`)
            } else {
                return(error.config)
            } 
    }
    });

    export const getOrderById = createAsyncThunk(
    'getOrderById',
    async (id: string| undefined) => {
        try {
            const res = await axiosInstance.get(`/orders/${id}`);
            if (res.data) {
                return res.data;
            }
        } catch (err) {
         const error = err as AxiosError
        if (error.response) {
                return(error.response.data)
            }else if (error.request) {
                return(`Error from request: ${error.message}`)
            } else {
                return(error.config)
            } 
        }
  }
);

export const getUserOrder = createAsyncThunk(
'users/orders',
async () => {
    try {
        const {data} = await axiosInstance.get("/orders/userOrder")
        return data
        // const response = await axiosInstance.get("/orders/userOrder")
        // const data: OrderTypes[] = response.data
        //     return data
        } catch (err) {
         const error = err as AxiosError
        if (error.response) {
                return(error.response.data)
            }else if (error.request) {
                return(`Error from request: ${error.message}`)
            } else {
                return(error.config)
            } 
        }
});