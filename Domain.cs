using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datalus.Web.Domain
{
    public class Educations
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
    }
}
