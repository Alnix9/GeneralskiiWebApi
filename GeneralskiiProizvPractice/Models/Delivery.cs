using System;
using System.Collections.Generic;

namespace GeneralskiiProizvPractice.Models;

public partial class Delivery
{
    public int DeliveryNumber { get; set; }

    public int? SupplierNumber { get; set; }

    public int? ProductCode { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public int? QuantitySupplied { get; set; }

    public string? InvoiceNumber { get; set; }

    public virtual Product? ProductCodeNavigation { get; set; }

    public virtual Supplier? SupplierNumberNavigation { get; set; }
}
