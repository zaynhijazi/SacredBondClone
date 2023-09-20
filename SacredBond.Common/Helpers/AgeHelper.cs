namespace SacredBond.Common.Helpers
{
    public static class AgeHelper
    {
        public static int? Calculate(DateTime? dateTime)
        {
            if (!dateTime.HasValue) return default;

            int age = DateTime.Today.Year - dateTime.Value.Year;
            if (dateTime.Value > DateTime.Today.AddYears(-age)) age--;

            return age;
        }
    }
}
