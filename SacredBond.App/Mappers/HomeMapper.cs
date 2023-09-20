using SacredBond.App.Models.Admin;
using SacredBond.App.Models.Home;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;

namespace SacredBond.App.Mappers
{
    public static class HomeMapper
    {
        public static HomeViewModel Map(SimpleProfileDto dto)
        {
            var viewModel = new HomeViewModel()
            {
                ProfileId = dto.ProfileId,
                ProfileStatus = dto.Status,
                ProfileStatusDate = dto.StatusChangedDate,
                ApprovedDate = dto.ApprovedDate,
                RejectedDate = dto.RejectedDate,
                SubmittedDate = dto.SubmittedDate,
                IsPending = dto.Status == ProfileStatus.Pending,
                IsApproved = dto.Status == ProfileStatus.Approved,
                IsRejected = dto.Status == ProfileStatus.Rejected,
                CompletedPercentage = 0
            };

            if (dto.IsPersonalCompleted) viewModel.CompletedPercentage += 10;
            if (!dto.IsPicturesCompleted) viewModel.CompletedPercentage -= 10;
            if (dto.IsEducationalProfessionalCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsMaritalCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsReligionCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsAboutCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsSpouseCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsHealthCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsFamilyCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsFinanceCompleted) viewModel.CompletedPercentage += 10;
            if (dto.IsContactCompleted) viewModel.CompletedPercentage += 10;

            return viewModel;
        }


        public static MatchDetails MapMatches(IQueryable<MatchDto> matches, bool isInterestedIn = false)
        {
            MatchDetails matchDetails = new MatchDetails();

            var currentMatches = matches.Where(m => m.Status == InterestedInStatus.Pending || m.Status == InterestedInStatus.Approved);

            matchDetails.Current = new List<MatchViewModel>();
            foreach (var item in currentMatches)
            {
                MatchViewModel match = new MatchViewModel();
                match.ProfileId = !isInterestedIn ? item.SpouseId : item.ProfileId;
                match.Status = item.Status.Value;
                match.StatusChangedDate = item.StatusChangedDate.Value;
                match.ProfileUId = !isInterestedIn ? item.SpouseUId : item.ProfileUId;
                match.DisplayedProfileIdentifier = $"{match.ProfileId}-{match.ProfileUId.ToString().Substring(0, 5)}";

                matchDetails.Current.Add(match);
            }


            var historicalMatches = matches.Where(m => m.Status == InterestedInStatus.Rejected
                                               || m.Status == InterestedInStatus.InReview
                                               || m.Status == InterestedInStatus.Canceled
                                               || m.Status == InterestedInStatus.Completed);

            matchDetails.Historical = new List<MatchViewModel>();
            foreach (var item in historicalMatches)
            {
                MatchViewModel match = new MatchViewModel();
                match.ProfileId = !isInterestedIn ? item.SpouseId : item.ProfileId;
                match.Status = item.Status.Value;
                match.StatusChangedDate = item.StatusChangedDate.Value;
                match.ProfileUId = !isInterestedIn ? item.SpouseUId : item.ProfileUId;
                match.DisplayedProfileIdentifier = $"{match.ProfileId}-{match.ProfileUId.ToString().Substring(0, 5)}";

                matchDetails.Historical.Add(match);
            }

            return matchDetails;
        }
    }
}
