import * as yup from "yup"

export const productSchema = yup.object({
    title: yup.string().required().min(2).max(25),
    price: yup.string().required().min(2).max(25),
    description: yup.string().required().min(2).max(25),
    // images: yup.mixed().test({
    //     test: (value) => value.length > 0,
    //     message: "file cannot be empty"
    // })
})