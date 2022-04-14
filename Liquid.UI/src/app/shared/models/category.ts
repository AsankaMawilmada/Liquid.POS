import { IBaseEntity } from "./";
export interface ICategory extends IBaseEntity {
    categoryId: number;
    categoryGuId: string;
    name: string;
    description: string;
}