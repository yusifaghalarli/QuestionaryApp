using Microsoft.AspNetCore.Mvc;
using QuestionaryApp.Application.Services.Abstract;
using QuestionaryApp.Application.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionaryApp.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
           _questionService = questionService;
        }



        [HttpGet]
        [ProducesResponseType(typeof(List<QuestionDTO>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionService.GetAllQuestions();
            return result.Count==0?NotFound():Ok(result);
        }
    }
}
