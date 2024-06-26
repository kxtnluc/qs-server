using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Data;
using Questionnaire.Models;
using Questionnaire.Models.DTOs;

namespace Questionnaire.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private QuestionnaireDbContext _dbContext;

        public QuestionController(QuestionnaireDbContext context)
        {
            _dbContext = context;
        }

        //==============================================================================<ENDPOINTS>=============================================================================================
        //===============GETS
        //============all
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_dbContext.Questions.ToList());

            }
     //============all with groups
            [HttpGet("grouped")]
            public IActionResult GetWithGroups()
            {
            var query = _dbContext.QuestionGroups
                .Include(q => q.Questions);

                var result = query
                    .Select(qg => new QuestionGroupDTO
                    {
                        Id = qg.Id,
                        Title = qg.Title,
                        Questions = qg.Questions.Select(q => new QuestionDTO
                        {
                            Id = q.Id,
                            Body = q.Body,
                            QuestionGroupId = q.QuestionGroupId,
                            PaidUsersOnly = q.PaidUsersOnly,
                            MultipleResponses = q.MultipleResponses
                        }).ToList()
                    }).ToList();

                return Ok(result);

            }
        //============all with groups and userResponses
        [HttpGet("uq/{userid}")]
        public IActionResult GetWithGroupsAndResponses(int userid)
        {
            var query = _dbContext.QuestionGroups
                .Include(q => q.Questions)
                .ThenInclude(q => q.UserQuestions);

            var result = query
                .Select(qg => new QuestionGroupDTO
                {
                    Id = qg.Id,
                    Title = qg.Title,
                    Questions = qg.Questions.Select(q => new QuestionDTO
                    {
                        Id = q.Id,
                        Body = q.Body,
                        QuestionGroupId = q.QuestionGroupId,
                        MultipleResponses = q.MultipleResponses,
                        PaidUsersOnly = q.PaidUsersOnly,
                        UserQuestions = q.UserQuestions.Where(uq => uq.UserProfileId == userid).Select(uq => new UserQuestionDTO //this is skitzo but whatever
                        {
                            Id = uq.Id,
                            Response = uq.Response,
                            UserProfileId = uq.UserProfileId,
                            QuestionId = uq.QuestionId,
                        }).ToList()
                    }).ToList()
                }).ToList();

            return Ok(result);

        }
        //===============POSTS
        //============one question
        [HttpPost]
        public IActionResult PostOneQuestion(Question questionToPost)
        {
            if (questionToPost == null) return BadRequest();

            _dbContext.Questions.Add(questionToPost);
            _dbContext.SaveChanges();

            return Created($"/api/question/{questionToPost.Id}", questionToPost);
        }
        //==============================================================================</ENDPOINTS>=============================================================================================
    }

}