import { ProductTransactionType } from "./product.transaction.type";
import { IProduct } from "./product";
import { ICustomer } from "./customer";
import { IBaseEntity } from "./base.entity";
export interface IProductTransaction extends IBaseEntity {
    productTransactionId: number;
    productOrderNumber: string;
    productId: number;
    customerId: number | null;
    quantity: number;
    purchasedPrice: number;
    type: ProductTransactionType;
    product?: IProduct;
    customer?: ICustomer;
}
