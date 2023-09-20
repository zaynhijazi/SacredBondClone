using System;
namespace SacredBond.Core.Domain
{
	public class ProfilePicture
	{
        public int ProfilePictureId { get; set; } // Primary key
        public string PictureUri { get; set; } // Store the URI of the image/blob
        public string SasToken { get; set; }   // Store the SAS token for the image/blob
        public int PictureNumber { get; set; } // Indicates if it's the first, second, or third picture

        // Foreign key to link to the associated profile using ProfileId
        public int ProfileId { get; set; }
    }
}

