using Microsoft.AspNetCore.Mvc;
using Questionnaire.Data;
using Questionnaire.Models;
using Questionnaire.Models.DTOs;

namespace Questionnaire.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private QuestionnaireDbContext _dbContext;

        public UserProfileController(QuestionnaireDbContext context)
        {
            _dbContext = context;
        }

        //==============================================================================<ENDPOINTS>=============================================================================================
        //===============GETS
        //============all
        [HttpGet]
        public IActionResult Get()
        {
            //var query = _dbContext.UserProfiles.Select(up => new UserProfileDTO
            //{
            //    Id = up.Id,
            //    Email = up.Email,
            //    UserName = up.UserName,
            //    MembershipId = up.MembershipId,
            //}).ToList();

            return Ok(_dbContext.UserProfiles.ToList());

        }
        //============one
        [HttpPut("{userid}/{isPaidUser}")]
        public IActionResult PaidUser(bool isPaidUser, int userid)
        {
            UserProfile foundUser = _dbContext.UserProfiles.SingleOrDefault(uq => uq.Id == userid);


            if (foundUser == null)
            {
                return NotFound();
            }

            foundUser.PaidUser = isPaidUser;
            _dbContext.SaveChanges();

            return NoContent();

        }
        //==============================================================================</ENDPOINTS>=============================================================================================
    }
}
