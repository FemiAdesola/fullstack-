export interface CategoryType {
    id: number | string;
    name: string;
    image: string;
}

export interface CreateCategoryType {
    name: string;
    image: File[] | string
    id: number | string;
}

export interface UpdateCategoryType{
    name: string;
    image: File[] | string
    id: number | string;
}

export interface UpdateCategoryProps{
    previousName: string | undefined |any
    previousImage: string |any
    id:  number|any
}