using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Questionnaire.Models;
using System.Runtime.ExceptionServices;

namespace Questionnaire.Data;
public class QuestionnaireDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<UserQuestion> UserQuestions { get; set; }
    public DbSet<QuestionGroup> QuestionGroups { get; set; }




    public QuestionnaireDbContext(DbContextOptions<QuestionnaireDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            Email = "QuestionnaireAdministrator@admin.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                Email = "QuestionnaireAdministrator@admin.comx",
                UserName = "Admin",
                MembershipId = 3,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            }
        );

        //Data Input===================================================

        modelBuilder.Entity<QuestionGroup>().HasData(
            new QuestionGroup
            {
                Id = 1,
                Title = "User"
            },
            new QuestionGroup
            {
                Id = 2,
                Title = "Pet"
            },
            new QuestionGroup
            {
                Id = 3,
                Title = "Bank"
            }
        );

        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                Id = 1,
                Body = "First Name",
                QuestionGroupId = 1,
                PaidUsersOnly = false,
                MultipleResponses = false,
            },
            new Question
            {
                Id = 2,
                Body = "Last Name",
                QuestionGroupId = 1,
                PaidUsersOnly = false,
            },
            //Pet Questions==========================
            new Question
            {
                Id = 3,
                Body = "Number of Pets",
                QuestionGroupId = 2,
                PaidUsersOnly = true,
                MultipleResponses = false,
            },
            new Question
            {
                Id = 4,
                Body = "Pet Name",
                QuestionGroupId = 2,
                PaidUsersOnly = true,
                MultipleResponses = true,
            },
            //Bank Questions==========================
            new Question
            {
                Id = 5,
                Body = "Bank Name",
                QuestionGroupId = 3,
                PaidUsersOnly = true,
                MultipleResponses = true,
            },
            new Question
            {
                Id = 6,
                Body = "Account Number",
                QuestionGroupId = 3,
                PaidUsersOnly = true,
                MultipleResponses = true,
            }
        );
        //=====================================UserQuestions
        modelBuilder.Entity<UserQuestion>().HasData(
            new UserQuestion
            {
                Id = 1,
                UserProfileId = 1,
                QuestionId = 1,
                Response = "Admin",
                PriorityNumber = 1,
            },
            new UserQuestion
            {
                Id = 2,
                UserProfileId = 1,
                QuestionId = 2,
                Response = "Administrator",
                PriorityNumber = 2,
            },
            new UserQuestion
            {
                Id = 3,
                UserProfileId = 1,
                QuestionId = 3,
                Response = "4",
                PriorityNumber = 1,
            },
            new UserQuestion
            {
                Id = 4,
                UserProfileId = 1,
                QuestionId = 4,
                Response = "Napoleon",
                PriorityNumber = 2,
            },
            new UserQuestion
            {
                Id = 5,
                UserProfileId = 1,
                QuestionId = 5,
                Response = "Bank of America",
                PriorityNumber = 1,
            }
        );

        modelBuilder.Entity<Membership>().HasData(
            new Membership
            {
                Id = 1,
                Name = "Free",
                Price = 0,
            },
            new Membership
            {
                Id = 2,
                Name = "Monthly",
                Price = 10,
            },
            new Membership
            {
                Id = 3,
                Name = "Yearly",
                Price = 60,
            },
            new Membership
            {
                Id = 4,
                Name = "Lifetime",
                Price = 300,
            }
        );

    }
}