import { CategoryType} from './category';
export interface ProductType {
    id: number | string;
    title: string;
    price: number;
    description: string;
    category: CategoryType; 
    // images: string[]
    images: string
    product?: ProductType | null;
}

export interface CreateProductType {
    title: string
    description: string
    price: number
    categoryId: number 
    images: string[]
    id?: number
}
export interface CreateProductWithImages{
    images:  File[]
    productCreate: CreateProductType

}
export interface UpdateProductType{
    id:number | string
    update: Partial<ProductType>
}

export interface UpdateValueType {
    title?: string 
    description?: string 
    price?: number
    id: number |string
    images: string[]
}
export interface UpdateProductProps {
  id: number|any
  previousTitle: string | undefined |any
  previousDescription: string | undefined |any
  previousPrice: number | any
  previousImage: string |any
}