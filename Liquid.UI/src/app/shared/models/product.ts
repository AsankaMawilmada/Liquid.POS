import { ICategory } from "./";
import { IBaseEntity } from "./base.entity";
import { ISupplier } from "./supplier";
export interface IProduct extends IBaseEntity {
    productId: number;
    productGuId: string;
    name: string;
    categoryId: number;
    supplierId: number;
    description: string;
    purchasedPrice: number;
    regularPrice: number;
    category?: ICategory;
    supplier?: ISupplier;
}