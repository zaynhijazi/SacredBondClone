using System;
namespace SacredBond.Common.DTOs
{
	public class BlobResponseDto
	{
        public string? Status { get; set; }
        public bool Error { get; set; }
        public BlobDto Blob { get; set; }
        public string SasToken { get; set; }

        public BlobResponseDto()
        {
            Blob = new BlobDto();
        }
    }
}

