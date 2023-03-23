import { createAsyncThunk} from "@reduxjs/toolkit";
import axios, { AxiosError, AxiosResponse} from "axios";

import axiosInstance from "../../common/axiosIntsance";
import { CategoryType, CreateCategoryType, UpdateCategoryType } from "../../types/category";


export const getAllCategories = createAsyncThunk(
    "getAllCategories",
    async () => {
        try {
            const jsondata = await axiosInstance.get("categories")
            return jsondata.data
        } catch (err) {
            const error = err as AxiosError
            if (error.response) {
                 return(`Error from response: ${error.response.status}`)
            }else if (error.request) {
                 return(`Error from request: ${error.request}`)
            } else {
                return(error.config)
            }
        }
    }
)

export const createCategory = createAsyncThunk(
    "createCategory",
    async (category: CreateCategoryType) => {
        try {
            const response = await axiosInstance.post("files/upload", {file:category.image}, {
                headers: { "Content-Type": "apllication/json" }
            })
            const url: string = response.data.location
            const categoryResponse = await axiosInstance.post("categories", {
                ...category,
                image: url
            })
            const data: CategoryType = categoryResponse.data
            return data
        } catch (err) {
            const error = err as AxiosError
            if (error.response) {
                console.log(`Error from response: ${error.message}`)
            }else if (error.request) {
                console.log(`Error from request: ${error.request}`)
            } else {
               console.log(error.config)
            }
        }
    }
)


export const deleteCategory = createAsyncThunk(
    "deleteCategory",
    async (id:string|undefined) => {
        try {
            const response: AxiosResponse<CategoryType, any> = await axiosInstance.delete(`categories/${id}`)
            return response.data
        } catch (err) {
            const error = err as AxiosError
            if (error.response) {
                console.log(error.response.data)
            } else if (error.request) {
                console.log(`Error from request: ${error.request}`)
            } else {
                console.log(error.config)
            }
        }
    }
)

export const updateCategory = createAsyncThunk(
    "updateCategory",
    async (update: UpdateCategoryType) => { 
        try {
            const response: AxiosResponse<CategoryType, any> = await axiosInstance.put(`categories/${update.id}`,
                {
                    name: update.name,
                    image: update.image,
                }
            )
            return response.data
        } catch (err) {
            const error = err as AxiosError
            if (error.response) {
                console.log(error.response.data)
            } else if (error.request) {
                console.log(`Error from request: ${error.request}`)
            } else {
                console.log(error.config)
            }
        }
    }
)
