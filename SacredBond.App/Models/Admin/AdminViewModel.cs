namespace SacredBond.App.Models.Admin
{
    public class AdminViewModel
    {
        public List<CountDetails> ProfileCounts { get; set; } = new List<CountDetails>();
        public List<CountDetails> MatchesCounts { get; set; } = new List<CountDetails>();
    }

    public class CountDetails
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }

    }
}
