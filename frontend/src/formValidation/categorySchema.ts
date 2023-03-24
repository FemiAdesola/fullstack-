import * as yup from "yup"

export const CategorySchema = yup.object({
    name: yup.string().required().min(2).max(25),
})