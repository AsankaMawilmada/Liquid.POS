import { IBaseEntity } from "./base.entity";
export interface ISupplier extends IBaseEntity {
    supplierId: number;
    supplierGuId: string;
    name: string;
    phone: string;
    addressLine1: string;
    addressLine2: string | null;
    city: string;
    state: string | null;
    postalCode: string;
}