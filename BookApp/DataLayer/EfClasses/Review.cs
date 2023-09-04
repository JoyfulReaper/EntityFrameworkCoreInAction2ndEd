using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses;
public class Review
{
    public int ReviewId { get; set; }
    public required string VoterName { get; set; }
    public int NumStars { get; set; }
    public string? Comment { get; set; }

    // Relationships
    public int BookId { get; set; }
}
