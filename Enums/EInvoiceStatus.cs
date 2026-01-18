namespace Invoices.Enums;

public enum EInvoiceStatus
{
    Draft,  // can be changed
    Issued, //sent to client, should not be changed
    Paid,   //
    Overdue,
    Cancelled // stornovana
}
