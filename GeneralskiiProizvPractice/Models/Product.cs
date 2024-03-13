using System;
using System.Collections.Generic;

namespace GeneralskiiProizvPractice.Models;

public partial class Product
{
    public int ProductCode { get; set; }

    public string? ProductName { get; set; }

    public int? QuantityInStock { get; set; }

    public string? UnitOfMeasurement { get; set; }

    public decimal? UnitPrice { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
