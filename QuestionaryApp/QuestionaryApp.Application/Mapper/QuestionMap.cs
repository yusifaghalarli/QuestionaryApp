

using AutoMapper;
using QuestionaryApp.Application.Services.DTO;
using QuestionaryApp.Core.Domain;

namespace QuestionaryApp.Application.Mapper
{
    class QuestionMap : Profile
    {
        public QuestionMap()
        {
            CreateMap<Question, QuestionDTO>();
        }
    }
}
