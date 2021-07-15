using AutoMapper;
using QuestionaryApp.Application.Services.DTO;
using QuestionaryApp.Core.Domain;

namespace QuestionaryApp.Application.Mapper
{
    public class ChoicesMap : Profile
    {
        public ChoicesMap()
        {
            CreateMap<Choice, ChoiceDTO>();
        }
    }
}
