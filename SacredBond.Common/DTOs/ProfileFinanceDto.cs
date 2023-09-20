using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileFinanceDto : SimpleProfileDto
    {
        public FinancesHandlingAfterMarriageOptions? FinancesHandlingAfterMarriage { get; set; }
        public bool? WifeContributeFinancially { get; set; }
        public bool? HusbandSoleProvider { get; set; }
        public YesNoMaybeOptions? WantToWorkAfterMarriage { get; set; }
        public YesNoMaybeOptions? WantWifeToWorkAfterMarriage { get; set; }
        public bool? HasDebts { get; set; }
        public Genders Gender { get; set; }

    }
}
