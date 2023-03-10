import { createAsyncThunk} from "@reduxjs/toolkit";
import axios, { AxiosError} from "axios";

import axiosInstance from "../../common/axiosIntsance";


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
