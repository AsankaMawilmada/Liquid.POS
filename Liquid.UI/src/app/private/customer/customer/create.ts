import { maxLength, required } from "@rxweb/reactive-form-validators";

export class Create {
  @required()
  @maxLength({ value: 50 })
  name?: string;

  @required()
  @maxLength({ value: 50 })
  phone?: string;

  @required()
  @maxLength({ value: 50 })
  addressLine1?: string;

  @maxLength({ value: 50 })
  addressLine2?: string;

  @required()
  @maxLength({ value: 50 })
  city?: string;

  @maxLength({ value: 50 })
  state?: string;

  @required()
  @maxLength({ value: 15 })
  postalCode?: string;
}

export class Edit extends Create{
  @required()
  customerId?: number;

  @required()
  customerGuId?: string;
}
