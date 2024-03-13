using System;
using System.Collections.Generic;

namespace GeneralskiiProizvPractice.Models;

public partial class Supplier
{
    public int SupplierNumber { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
