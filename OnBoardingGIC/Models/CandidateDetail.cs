using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardingGIC.Models
{
    public class CandidateDetail
    {
        public int id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Street name")]
        public string AddressOne { get; set; }
        
        [Display(Name = "City Line")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Skills")]
        [DataType(DataType.MultilineText)]
        public string Skill { get; set; }

        [Display(Name = "Certifications")]
        [DataType(DataType.MultilineText)]
        public string Certifications { get; set; }

       



    }
}