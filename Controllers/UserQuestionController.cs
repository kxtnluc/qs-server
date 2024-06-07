using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Data;
using Questionnaire.Models;
using Questionnaire.Models.DTOs;

namespace Questionnaire.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class UserQuestionController : ControllerBase
    {
        private QuestionnaireDbContext _dbContext;

        public UserQuestionController(QuestionnaireDbContext context)
        {
            _dbContext = context;
        }

        //==============================================================================<ENDPOINTS>=============================================================================================
        //===============GETS
        //============all
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.UserQuestions.ToList());

        }
        //============all from one user
        [HttpGet("{userid}")]
        public IActionResult GetUsersUserQuestions(int userid)
        {
            List<UserQuestion> foundUserQuestions = _dbContext.UserQuestions
                .Where(uq => uq.UserProfileId == userid)
                .Include(q => q.Question)
                .ToList();

            if (foundUserQuestions == null) return BadRequest();

            var result = foundUserQuestions.Select(uq => new UserQuestionDTO
            {
                Id = uq.Id,
                UserProfileId = uq.UserProfileId,
                QuestionId = uq.QuestionId,
                Question = new QuestionDTO
                {
                    Id = uq.Question.Id,
                    Body = uq.Question.Body,
                    QuestionGroupId = uq.Question.QuestionGroupId,
                },
                Response = uq.Response
            }).ToList();

            return Ok(foundUserQuestions);

        }
        //===============POSTS
        //============one
        [HttpPost]
        //[Authorize]
        public IActionResult Post(UserQuestion userQuestionToPost)
        {

            if (userQuestionToPost == null)
            {
                return BadRequest();
            }

            _dbContext.Add(userQuestionToPost);
            _dbContext.SaveChanges();

            return Created($"/api/cookbook/{userQuestionToPost.Id}", userQuestionToPost);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, string responseUpdate)
        {

            UserQuestion foundUserQuestion = _dbContext.UserQuestions.SingleOrDefault(uq => uq.Id == id);


            if (foundUserQuestion == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(responseUpdate)) responseUpdate = foundUserQuestion.Response;

            foundUserQuestion.Response = responseUpdate;
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserQuestion foundUserQuestion = _dbContext.UserQuestions.SingleOrDefault(uq => uq.Id == id);

            if (foundUserQuestion == null) return NotFound();

            _dbContext.Remove(foundUserQuestion);
            _dbContext.SaveChanges();

            return NoContent();
        }

        //==============================================================================</ENDPOINTS>=============================================================================================
    }
}
