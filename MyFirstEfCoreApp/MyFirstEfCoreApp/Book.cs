using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstEfCoreApp;
public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;

    public DateTime PublishedOn { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; }
}
