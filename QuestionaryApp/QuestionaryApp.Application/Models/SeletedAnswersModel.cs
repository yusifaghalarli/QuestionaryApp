namespace QuestionaryApp.Application.Models
{
    public class SeletedAnswersModel
    {
        public int QuestionId { get; set; }
        public int[] SelectedChoiceIds { get; set; }
    }
}
