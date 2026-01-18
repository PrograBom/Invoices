using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Invoices.Enums;

public enum EUserRole
{

    Administrator = 1,
    Accountant = 2,
    Viewer = 3,
    Customer = 4  // Externý klient, nie User
}