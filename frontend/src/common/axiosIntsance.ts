import axios from "axios"

const axiosInstance = axios.create  ({
    baseURL: "https://backend-fem.azurewebsites.net/api/v1/"
})

// const axiosInstance = axios.create  ({
//     baseURL: "https://localhost:7187/api/v1"
// })


// const axiosInstance = axios.create  ({
//     baseURL: "http://localhost:5131/api/v1"
// })

export default axiosInstance