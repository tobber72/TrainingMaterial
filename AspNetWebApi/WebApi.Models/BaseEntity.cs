using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    abstract class BaseEntity
    {
        public List<Link> Links { get; set; }
    }
}
