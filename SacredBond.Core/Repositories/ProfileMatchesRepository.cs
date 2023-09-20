using SacredBond.Common.DTOs;
using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Repositories
{
    public class ProfileMatchesRepository : BaseRepository<ProfileMatches>, IProfileMatchesRepository
    {
        public ProfileMatchesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<MatchDto> GetMatchesData()
        {
            var query =
                (from pm in DataContext.ProfileMatches
                 join profile in DataContext.Profile on pm.ProfileId equals profile.ProfileId
                 join puser in DataContext.User on profile.ProfileId equals puser.ProfileId
                 join spouse in DataContext.Profile on pm.SpouseId equals spouse.ProfileId
                 join suser in DataContext.User on spouse.ProfileId equals suser.ProfileId

                 //where exams.Id == id
                 select new MatchDto
                 {
                     MatchId = pm.MatchId,
                     ProfileId = pm.ProfileId,
                     ProfileUserFirstName = puser.FirstName,
                     ProfileUserLastName = puser.LastName,
                     ProfileUserGender = puser.Gender,
                     ProfileUserEmail = puser.Email,
                     ProfileUserPhone = puser.PhoneNumber,
                     SpouseId = pm.SpouseId,
                     SpouseUserFirstName = suser.FirstName,
                     SpouseUserLastName = suser.LastName,
                     SpouseUserGender = suser.Gender,
                     SpouseUserEmail = suser.Email,
                     SpouseUserPhone = suser.PhoneNumber,
                     Status = pm.Status,
                     StatusChangedDate = pm.StatusChangedDate,
                     ApprovedDate = pm.ApprovedDate,
                     RejectedDate = pm.RejectedDate,
                     ProfileUId = profile.ProfileUId,
                     SpouseUId = spouse.ProfileUId,
                 });

            return query;
        }
    }

    public interface IProfileMatchesRepository : IBaseRepository<ProfileMatches>
    {
        IQueryable<MatchDto> GetMatchesData();
    }
}
