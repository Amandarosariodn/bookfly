using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Domain.GoogleBooks.Entities
{
    public class Item
    {
        public string Id { get; set; }
    public VolumeInfo VolumeInfo { get; set; }
    }
}