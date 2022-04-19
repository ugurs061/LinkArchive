using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkArchive
{
    public class tblLinks
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string CreateOwner { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; }
    }

    public class tblLinksDto : tblLinks
    {
        public string CategoryName { get; set; }
    }
}
