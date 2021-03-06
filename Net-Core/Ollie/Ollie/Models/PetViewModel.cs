﻿using System.ComponentModel.DataAnnotations;

namespace Ollie.Models
{
    public class PetViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Breed")]
        [StringLength(50)]
        public string Breed { get; set; }
        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Gender")]
        [StringLength(10)]
        public string Gender { get; set; }
    }
}