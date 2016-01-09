using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Task2_CarOwners.Models
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The brand is required")]
        [Display(Name = "Brand")]
        public string CarBrand { get; set; }

        [Required(ErrorMessage = "The model is required")]
        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Display(Name = "Type")]
        public string CarType { get; set; }

        [Display(Name = "Price")]
        public int? Price { get; set; }

        [Display(Name = "Year of Manufacture")]
        [Range(1886, 2016, ErrorMessage = "Choose the year of car manufacture from 1886 till 2016")]
        public int? YearOfManufacture { get; set; }

        [Required(ErrorMessage = "The number is required")]
        [Display(Name = "Number")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "The number length have to be 6 characters")]
        [RegularExpression(@"[A-z]{2}\d{4}[A-z]{2}", ErrorMessage = "Incorrect number format")]
        public string Number { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }

        public Car()
        {
            Owners = new List<Owner>();
        }

        public override string ToString()
        {
            string str = CarBrand + " " + CarModel + ", " + Number;
            return str;
        }
    }
}