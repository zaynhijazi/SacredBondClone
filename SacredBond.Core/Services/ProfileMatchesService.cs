using Microsoft.Extensions.Logging;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using SacredBond.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Services
{
    public class ProfileMatchesService : BaseService, IProfileMatchesService
    {
        private readonly IProfileMatchesRepository profileMatchesRepository;
        private readonly IProfileMatchStatusChangeRepository profileMatchStatusChangeRepository;
        private readonly IUserRepository userRepository;

        public ProfileMatchesService(ILogger<ProfileMatchesService> logger, 
            IPrincipal principal,
            IProfileMatchesRepository profileMatchesRepository,
            IProfileMatchStatusChangeRepository profileMatchStatusChangeRepository,
            IUserRepository userRepository) : base(logger, principal)
        {
            this.profileMatchesRepository = profileMatchesRepository;
            this.profileMatchStatusChangeRepository = profileMatchStatusChangeRepository;
            this.userRepository = userRepository;
        }

        public ProfileMatches? GetProfileMatch(int profileId, int spouseId)
        {
            return profileMatchesRepository.GetAsQueryable(p => p.ProfileId == profileId && p.SpouseId == spouseId).FirstOrDefault();
        }

        public IQueryable<MatchDto> GetProfileMatches(int profileId)
        {
            return profileMatchesRepository.GetMatchesData().Where(m => m.ProfileId == profileId);
        }

        public IQueryable<MatchDto> GetMatchesBySpouseId(int spouseId)
        {
            return profileMatchesRepository.GetMatchesData().Where(m => m.SpouseId == spouseId);
        }
        public IQueryable<MatchDto> GetMatchesFullData()
        {
            return profileMatchesRepository.GetMatchesData();
            //return allMatches.Where(m => m.Status == status);
        }

        public ProfileMatches GetMatch(int profileId, int spouseId)
        {
            return profileMatchesRepository.GetAsQueryable(m => m.ProfileId == profileId && m.SpouseId == spouseId).FirstOrDefault();
        }

        public List<MatchDto> GetProfileMatchesDetails(int profileId)
        {
            var matches = profileMatchesRepository.GetAsQueryable(m => m.ProfileId == profileId).ToList();
            var spouses = matches.Select(m => m.SpouseId).ToList();
            var users = userRepository.GetAsQueryable(u => spouses.Contains(u.ProfileId)).ToList();

            List<MatchDto> matchesList = new List<MatchDto>();
            foreach (var match in matches)
            {
                MatchDto matchDto = new MatchDto();
                matchDto.SpouseId = match.SpouseId;
                matchDto.ApprovedDate = match.ApprovedDate;
                matchDto.RejectedDate = match.RejectedDate;
                matchDto.ReviewedDate = match.InReviewDate;
                matchDto.CompletedDate = match.CompletedDate;
                matchDto.Status = match.Status;
                matchDto.StatusChangedDate = match.StatusChangedDate;

                var user = users.Where(u => u.ProfileId == match.SpouseId).Select(u => u).FirstOrDefault();
                if (user != null)
                {
                    matchDto.SpouseUserEmail = user.Email;
                    matchDto.SpouseUserFirstName = user.FirstName;
                    matchDto.SpouseUserLastName = user.LastName;
                    matchDto.SpouseUserPhone = user.PhoneNumber;
                    matchDto.SpouseUserGender = user.Gender;
                }

                matchesList.Add(matchDto);
            }

            return matchesList;
        }

        public async Task UpdateMatchStatus(int profileId, int spouseId, string userEmail, 
            InterestedInStatus newStatus, InterestedInStatus oldStatus)
        {
            var match = GetMatch(profileId, spouseId);
            if (match == null)
            {
                throw new Exception($"Unable to find match with profile Id: {profileId}, and spouse Id: {spouseId}");
            }

            switch (newStatus)
            {
                case InterestedInStatus.Rejected:
                    match.RejectedDate = DateTime.UtcNow;
                    break;
                case InterestedInStatus.InReview:
                    match.InReviewDate = DateTime.UtcNow;
                    break;
                case InterestedInStatus.Completed:
                    match.CompletedDate = DateTime.UtcNow;
                    break;
                case InterestedInStatus.Approved:
                    match.ApprovedDate = DateTime.UtcNow;
                    break;
                case InterestedInStatus.Canceled:
                    match.CanceledDate = DateTime.UtcNow;
                    break;
                default:
                    break;
            }
            match.InReviewDate = DateTime.UtcNow;
            match.Status = newStatus;
            match.StatusChangedDate = DateTime.UtcNow;
            match.UpdateBy = userEmail;
            match.UpdateTime = DateTime.UtcNow;

            await profileMatchesRepository.SaveChangesAsync();

            ProfileMatchStatusChange profileMatchStatusChange = new ProfileMatchStatusChange();
            profileMatchStatusChange.ToStatus = newStatus;
            profileMatchStatusChange.FromStatus = oldStatus;
            profileMatchStatusChange.CreatedBy = userEmail;
            profileMatchStatusChange.CreateTime = DateTime.UtcNow;
            profileMatchStatusChange.MatchId = match.MatchId;

            await profileMatchStatusChangeRepository.AddAsync(profileMatchStatusChange);
        }
        public List<CountDetailsDto> GetMatchesCounts()
        {
            var matches = profileMatchesRepository.GetAll();

            var interestedInStatusList = Enum.GetNames(typeof(InterestedInStatus));
            List<CountDetailsDto> matchesCount = new List<CountDetailsDto>();

            var matchesData = matches.GroupBy(_ => _.Status).Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            }).
            OrderByDescending(gp => gp.Count).ToList();


            foreach (var item in interestedInStatusList)
            {
                matchesCount.Add(new CountDetailsDto
                {
                    Name = item,
                    Count = matchesData.Where(d => d.Name.ToString() == item).Select(d => d.Count).FirstOrDefault()
                });
            }

            return matchesCount;
        }
    }
    public interface IProfileMatchesService
    {
        ProfileMatches? GetProfileMatch(int profileId, int spouseId);
        IQueryable<MatchDto> GetProfileMatches(int profileId);
        IQueryable<MatchDto> GetMatchesBySpouseId(int spouseId);
        IQueryable<MatchDto> GetMatchesFullData();
        List<MatchDto> GetProfileMatchesDetails(int profileId);
        ProfileMatches GetMatch(int profileId, int spouseId);
        Task UpdateMatchStatus(int profileId, int spouseId, string userEmail, InterestedInStatus newStatus, InterestedInStatus oldStatus);
        List<CountDetailsDto> GetMatchesCounts();
    }
}
