import { ReactNode } from "react"

export type Role = "admin" | "customer"
export interface UserType  extends UserForm{
    id: number
    role: Role
    avatar: string
}
export interface UserReducer{
    userList: UserType[]
    currentUser?: UserType
    access_token?: string
}

export interface Authentications {
    email: string
    password: string
}

export interface ReturnedAuthentications{
access_token: string
}

export interface CreateUser{
    email: string
    password: string
    name: string
    role: Role
    avatar: string
}
export interface UserForm{
    email: string
    password: string
    name: string
    avatar: File[] | string
    role: Role
}

export type FormTypes = {
  children: ReactNode;
  title: string;
  src?: string;
  meta?: string;
};


export type BoardWrapperType ={
    children: ReactNode;
    cols: any;
}