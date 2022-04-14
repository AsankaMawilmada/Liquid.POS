import { IBaseEntity } from "./base.entity";
export interface ICustomer extends IBaseEntity {
    customerId: number;
    customerGuId: string;
    name: string;
    phone: string;
    addressLine1: string;
    addressLine2?: string;
    city: string;
    state?: string;
    postalCode: string;
}