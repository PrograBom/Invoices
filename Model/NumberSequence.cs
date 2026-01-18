namespace Invoices.Model;

public class NumberSequence : BaseModelEntity
{
    public Guid CompanyId { get; set; } // FK na Company (Tenant)

    public string Name { get; set; } // Napr. "Faktúry", "Zálohové faktúry"
    public string Prefix { get; set; } // Napr. "INV", "FA", "VF"
    public string Suffix { get; set; } // Napr. "/2025"

    public int LastNumber { get; set; } // Posledné použité číslo (napr. 15)
    public int Padding { get; set; } // Na koľko miest doplniť nuly (napr. 4 -> 0015)

    public int Year { get; set; } // Rok, ku ktorému sa sekvencia viaže

    // Šablóna formátu, napr: "{Prefix}{Year}{Number}"
    public string Format { get; set; }

    public virtual Company Company { get; set; }
}
