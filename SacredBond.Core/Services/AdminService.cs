using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using SacredBond.Core.Email;
using SacredBond.Core.Mappers;
using SacredBond.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Services
{
    public class AdminService : BaseService, IAdminService
    {
        private readonly IAdminProfileRepository adminProfileRepository;
        private readonly IProfileRepository profileRepository;
        private readonly UserManager<User> userManager;
        private readonly IProfileMatchesRepository profileMatchesRepository;
        private readonly IUserRepository userRepository;
        private readonly IEmailSender emailSender;

        public AdminService(ILogger<AdminService> logger,
            IPrincipal principal,
            IEmailSender emailSender) : base(logger, principal)
        {
            this.emailSender = emailSender;
        }

        public async Task SendMessageForMatchStatus(InterestedInStatus status, string recipientEmail, string spouseName)
        {
            if (status == InterestedInStatus.Rejected || status == InterestedInStatus.Canceled)
            {
                string? subject;
                string? messageBody = "</br>";
                if (status == InterestedInStatus.Rejected)
                {
                    subject = "Reject Confirmation";
                    messageBody += $"Relationship with {User.FirstName} {User.LastName} was unfortunately rejected.";
                }
                else
                {
                    subject = "Cancel Confirmation";
                    messageBody += $"Relationship with {spouseName} was unfortunately canceled by admin.";
                }

                await SendMessage(subject, messageBody, recipientEmail);
            }
        }

        public async Task SendMessage(string subject, string messageBody, string recipientEmail)
        {
            if (!string.IsNullOrEmpty(recipientEmail))
            {
                await emailSender.SendEmailAsync(recipientEmail, subject, messageBody);
            }
        }
    }

    public interface IAdminService
    {
        Task SendMessageForMatchStatus(InterestedInStatus status, string recipientEmail, string spouseName);
        Task SendMessage(string subject, string messageBody, string recipientEmail);
    }
}
