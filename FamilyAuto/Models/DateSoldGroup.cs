using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FamilyAuto.Models
{
    public class DateSoldGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateSold { get; set; }

        public int SoldCount { get; set; }
    }

    public class MakeSoldGroup
    {
        public string MakeSold { get; set; }
        public int MakeSoldCount { get; set; }
    }
}