using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses;
public class Tag
{
    [Key]
    [Required]
    [MaxLength(40)]
    public required string TagId { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
