using Datalus.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datalus.Web.Models.ViewModels
{
    public class EducationsViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public int UserProfileId { get; set; }
    }
}
