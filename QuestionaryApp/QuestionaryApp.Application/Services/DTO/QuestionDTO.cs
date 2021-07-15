using System.Collections.Generic;

namespace QuestionaryApp.Application.Services.DTO
{
    public class QuestionDTO
    {
        /// <summary>
        /// Id of question
        /// </summary>
        public int Id { get;  set; }
        /// <summary>
        /// Text of question
        /// </summary>
        public string Text { get;  set; }
        /// <summary>
        /// Indicates whether given question has multiselect option
        /// </summary>
        public bool HasMultiSelect { get;  set; }
        /// <summary>
        /// List of choices of question
        /// </summary>
        public List<ChoiceDTO> Choices { get;  set; }
      
    }
}
