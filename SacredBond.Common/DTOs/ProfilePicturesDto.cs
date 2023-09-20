using System;
namespace SacredBond.Common.DTOs
{
	public class ProfilePicturesDto : SimpleProfileDto
	{
        public ProfilePicturesDto()
        {
            pictures = new List<PictureDto>();
        }
        public List<PictureDto> pictures { get; set; }
    }

}

