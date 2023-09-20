using System;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
	public class ProfilePicturesViewModel : BaseProfileViewModel
	{
        public ProfilePicturesViewModel()
        {
            pictures = new List<PictureViewModel>();
        }
        public List<PictureViewModel> pictures { get; set; }
    }
}

