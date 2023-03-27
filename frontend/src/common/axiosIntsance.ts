import axios from "axios"

const axiosInstance = axios.create  ({
    baseURL: "https://backend-femi.azurewebsites.net/api/v1/"
})

// const axiosInstance = axios.create  ({
//     baseURL: "https://api.escuelajs.co/api/v1"
// })
export default axiosInstance
