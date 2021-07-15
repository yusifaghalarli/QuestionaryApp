using Microsoft.AspNetCore.Mvc;
using QuestionaryApp.Application.Models;
using QuestionaryApp.Application.Services.Abstract;
using QuestionaryApp.Application.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionaryApp.Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : Controller
    {

        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

      
        [HttpPost]
        public async Task<IActionResult> AnswerQuestion(AnswerQuestionModel model)
        {
            bool result =await _answerService.AnswerQuestion(model);
            return result ? Ok() : BadRequest();
        }

    }
}
