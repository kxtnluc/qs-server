using Microsoft.AspNetCore.Identity;

namespace Questionnaire.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public int MembershipId { get; set; }
    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }

}