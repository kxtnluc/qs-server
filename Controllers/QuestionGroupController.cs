using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Data;
using Questionnaire.Models;

namespace Questionnaire.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class QuestionGroupController : ControllerBase
    {
        private QuestionnaireDbContext _dbContext;

        public QuestionGroupController(QuestionnaireDbContext context)
        {
            _dbContext = context;
        }

        //==============================================================================<ENDPOINTS>=============================================================================================
        //===============GETS
        //============all
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.QuestionGroups.ToList());

        }
    //===============POSTS
        //============one group
        [HttpPost]
        public IActionResult PostQuestionGroup(QuestionGroup qgToPost)
        {
            if (qgToPost == null) return BadRequest();

            _dbContext.QuestionGroups.Add(qgToPost);
            _dbContext.SaveChanges();

            return Created($"/api/question/{qgToPost.Id}", qgToPost);
        }
    }
    //==============================================================================</ENDPOINTS>=============================================================================================
}
