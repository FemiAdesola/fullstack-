import { createSlice } from "@reduxjs/toolkit";
import { AxiosError } from "axios";

import { UserReducer} from '../../types/user'; 
import { createUserWithSignUp, getAllUsers, getUserBydId, loginUser, userAuthentication } from "../method/userMethod";

const initialState: UserReducer = {
    userList: [],
    
}

const userSlice = createSlice({
    name: "userSlice",
    initialState,
    reducers: {
         userLogout: (state) => {
            state = initialState
            return state
        }
    },
    extraReducers: (build) => {
        build.addCase(getAllUsers.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                return state
            } else {
               state.userList = action.payload
            }
            })
            .addCase(userAuthentication.fulfilled, (state, action) => {
                if (action.payload instanceof AxiosError) {
                    return state
                } else {
                    state.currentUser = action.payload
                }
            })
            .addCase(loginUser.fulfilled, (state, action) => {
                if (action.payload instanceof AxiosError) {
                    return state
                } else {
                    state.currentUser = action.payload
                }
            })
            .addCase(createUserWithSignUp.fulfilled, (state, action) => {
              if (action.payload instanceof AxiosError) {
                  if (action.payload.request) {
                       console.log("requesterror", action.payload.request)
                  } else {
                      console.log("requesterror", action.payload.response)
                   }
                }
            })
            .addCase(getUserBydId.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                        return state
                    } else {
                    state.userList = action.payload
                    }
            })
            .addCase(getUserBydId.pending, (state, action) => {
                return state
            })
            .addCase(getUserBydId.rejected, (state, action) => {
                return state
            })
    }
});

const userReducer = userSlice.reducer
export const { userLogout } = userSlice.actions;
export default userReducer
