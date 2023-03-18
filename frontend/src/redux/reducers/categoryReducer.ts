import { createSlice } from "@reduxjs/toolkit";
import { AxiosError } from "axios";

import { CategoryType } from "../../types/category";
import { createCategory, getAllCategories } from "../method/categoryMethod";

const initialState: CategoryType[] = []

const categorySlice = createSlice({
    name: "categorySlice",
    initialState: initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(getAllCategories.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state
            } else if (!action.payload) {
                return state
            }
                return action.payload
            })
            .addCase(createCategory.fulfilled, (state, action) => {
                if (action.payload) {
                    state.push(action.payload)
                } else {
                    return state
                }
            })
    }
});

const categoryReducer = categorySlice.reducer
export default categoryReducer