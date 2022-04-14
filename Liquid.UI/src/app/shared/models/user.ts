import { IBaseEntity } from "./base.entity";
import { UserRole } from "./user.role";
export interface IUser extends IBaseEntity {
    userId: number;
    userGuId: string;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    username: string;
    role: UserRole;
    active: boolean;
}