using System;
using System.Collections.Generic;

namespace AirTravels.Models;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
