using System;
namespace SacredBond.Common.DTOs
{
	public class PictureDto
	{
        public int ProfilePictureId { get; set; } // Primary key
        public string PictureUri { get; set; } = "NoValue"; // Store the URI of the image/blob
        public string SasToken { get; set; } = "NoValue"; // Store the SAS token for the image/blob
        public int PictureNumber { get; set; } // Indicates if it's the first, second, or third picture
        public int ProfileId { get; set; }
        public bool IsChanged;
    }
}

