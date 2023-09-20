using SacredBond.Common.Enums;

namespace SacredBond.App.Models
{
    public class ConfirmationViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ModalActionText { get; set; } = string.Empty;
        public string ModalId { get; set; }= string.Empty;
        public bool SendMessageModal { get; set; } = false;
        //public InterestedInStatus NewStatus { get; set; }
    }
}
