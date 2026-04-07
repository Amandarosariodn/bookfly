using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Domain.GoogleBooks.Entities
{
    public class VolumeInfo
{
    public string Title { get; set; }

    public List<string> Authors { get; set; }

    public string Description { get; set; }

    public int? PageCount { get; set; }

    public string PublishedDate { get; set; }

    public ImageLinks ImageLinks { get; set; }

}
}