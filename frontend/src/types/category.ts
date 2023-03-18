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