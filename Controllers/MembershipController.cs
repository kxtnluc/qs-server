using Microsoft.AspNetCore.Mvc;
using Questionnaire.Data;

namespace Questionnaire.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private QuestionnaireDbContext _dbContext;

        public MembershipController(QuestionnaireDbContext context)
        {
            _dbContext = context;
        }

        //==============================================================================<ENDPOINTS>=============================================================================================
        //===============GETS
        //============all
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Memberships.ToList());

        }
    }
    //============one
    //==============================================================================</ENDPOINTS>=============================================================================================
}
