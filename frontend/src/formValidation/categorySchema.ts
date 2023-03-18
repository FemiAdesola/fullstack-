import * as yup from "yup"

export const CategorySchema = yup.object({
    name: yup.string().required().min(2).max(25),

    // image: yup.mixed().test({
    //     test: (value) => value.length > 0,
    //     message: "file cannot be empty"
    // })
})