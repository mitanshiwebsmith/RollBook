using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RollBook.Models
{
    public class RollMaster
    {
        [Key]
        public int RollID { get; set; }

        [Required(ErrorMessage = "Please enter StudentName")]
        public string RollNo { get; set; }

        public string OpMtr { get; set; }

        public string CbMtr { get; set; }
        public int SizeID { get; set; }
        public string DNR { get; set; }
        public string QW { get; set; }
        public string TW { get; set; }
        public string NW { get; set; }
        public int QualityID { get; set; }
        public string QualityName { get; set; }
        public int LoomID { get; set; }
        public string LoomNo { get; set; }
        public string Size { get; set; }
    }

    public class QualityMaster
    {
        public int QualityID { get; set; }

        public string QualityName { get; set; }
    }

    public class LoomMaster
    {
        public int LoomID { get; set; }

        public string LoomNo { get; set; }
    }

    public class SizeMaster
    {
        public int SizeID { get; set; }

        public string Size { get; set; }

        public string TW { get; set; }
    }
}