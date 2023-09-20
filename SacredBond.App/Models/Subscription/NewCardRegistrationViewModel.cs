using System;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Subscription
{
	public class NewCardRegistrationViewModel
	{
        public NewCardRegistrationViewModel()
        {

        }

        public string stripeCustomerId { get; set; }

        [Required]
        [RegularExpression(@"(^\d{12}$)|(^\d{13}$)|(^\d{14}$)|(^\d{15}$)|(^\d{16}$)", ErrorMessage = "Credit card numbers are between 12-16 digits. Special characters are not accepted")]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Month")]
        public int EXPMonth { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int EXPYear { get; set; }

        [Required]
        [Display(Name = "CVC")]
        public string CVC { get; set; }

    }
}

