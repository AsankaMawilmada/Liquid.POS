using System.ComponentModel;

namespace Liquid.Core.Enums
{
    public enum UserRole
    {
        [Description("Administrator")]
        Administrator = 1,

        [Description("Purchase Officer")]
        PurchaseOfficer = 2,

        [Description("Cashier")]
        Cashier = 3
    }
}
