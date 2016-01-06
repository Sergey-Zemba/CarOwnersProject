using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2_CarOwners.Models
{
    public class Owner
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The first name is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The year of birth is required")]
        [Display(Name = "Year of birth")]
        [Range(1900, 2000, ErrorMessage = "Choose the year of birth from 1900 till 2000")]
        public int YearOfBirth { get; set; }

        [Display(Name = "Driving experience")]
        public int? DrivingExperience { get; set; }

        [Display(Name = "Cars")]
        public virtual ICollection<Car> Cars { get; set; }

        public Owner()
        {
            Cars = new List<Car>();
        }
    }
}