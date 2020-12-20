using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingGIC.Models
{
    public class Document
    {

        [Key]
        public int documentId { get; set; }


        public string UserID { get; set; }

        [Display(Name ="10th Standard Result")]
        public byte[] tenStandard { get; set; }

        [Display(Name = "12th Standard Result")]
        public byte[] twelveStandard { get; set; }

        /* [Display(Name = "Under Graduate Certificate")]
         public byte[] ugCertificate { get; set; }

         [Display(Name = "Adhaar Card")]
         public byte[] adhaarCard { get; set; }

         [Display(Name = "Passport")]
         public byte[] passPort { get; set; }*/

        /*[DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }*/



    }
}