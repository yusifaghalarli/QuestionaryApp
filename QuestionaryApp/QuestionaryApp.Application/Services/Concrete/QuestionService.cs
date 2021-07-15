using AutoMapper;
using QuestionaryApp.Application.Repository;
using QuestionaryApp.Application.Services.Abstract;
using QuestionaryApp.Application.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionaryApp.Application.Services.Concrete
{

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository,IMapper mapper)
        {
           _questionRepository = questionRepository;
           _mapper = mapper;
        }
        public async Task<List<QuestionDTO>> GetAllQuestions()
        {
            var questions = await _questionRepository.GetAllAsync();
            return _mapper.Map<List<QuestionDTO>>(questions);
        }

    }
}
