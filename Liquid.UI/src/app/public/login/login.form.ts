import { maxLength, required } from "@rxweb/reactive-form-validators";

export class LoginForm {
    @required()
    @maxLength({ value: 75 })
    username?: string;

    @required()
    @maxLength({ value: 75 })
    password?: string;
}
