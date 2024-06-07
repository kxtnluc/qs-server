using Microsoft.AspNetCore.Mvc;
using Questionnaire.Data;

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
    }
    //============one
    //==============================================================================</ENDPOINTS>=============================================================================================
}
