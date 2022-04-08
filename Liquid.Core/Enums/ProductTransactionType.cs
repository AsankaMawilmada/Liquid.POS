using System.ComponentModel;

namespace Liquid.Core.Enums
{
    public enum ProductTransactionType
    {
        [Description("Purchase")]
        Purchase = 1,

        [Description("Purchase Return")]
        PurchaseReturn = 2,

        [Description("Sale")]
        Sale = 3,

        [Description("Sale Return")]
        SaleReturn = 4,

        [Description("Damage")]
        Damage = 5,

        [Description("Expired")]
        Expired = 6,
    }
}