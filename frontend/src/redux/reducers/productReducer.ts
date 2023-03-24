import { createSlice } from "@reduxjs/toolkit";
import { AxiosError } from "axios";

import { ProductType } from "../../types/product";
import { createProduct, createProductWithImages, deleteProduct, getAllProducts, getProductById, sortByTitle, sortProductByPrice, updateProduct } from "../method/productMethod";

const initialState: ProductType[] = []

const productSlice = createSlice({
    name: "productSlice",
    initialState: initialState,
    reducers: {
        sortByPrice: sortProductByPrice,
        sortByName : sortByTitle,
    },
    extraReducers: (build) => {
        build.addCase(getAllProducts.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state
            } else if (!action.payload) {
                return state
            }
            return action.payload
        })
        .addCase(getProductById.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state
                } else {
                   return action.payload
                }
        })
         .addCase(createProduct.fulfilled, (state, action) => {
            if (action.payload) {
                state.push(action.payload)
            } else {
                return state
            }
        })
        .addCase(createProductWithImages.fulfilled, (state, action) => {
            if (action.payload) {
                state.push(action.payload)
            } else {
                return state 
            }
        })
        .addCase(updateProduct.fulfilled, (state, action) => {
            return state.map(product => {
                if (product.id === action.payload?.id) {
                    return action.payload
                }
                return product
            })
        })
        .addCase(deleteProduct.fulfilled, (state, action) => { 
            return state.filter(item => {
                if (item.id !== action.payload?.id) {
                    return action.payload
                }
                return state
            })
        })
    }

})

const productReducer = productSlice.reducer
export const {sortByPrice, sortByName } = productSlice.actions
export default productReducer