namespace QuestionaryApp.Core.Domain
{
    public class Choice : Entity
    {
        public Choice()
        {

        }

        public Choice(int id , int questionId, string text)
        {
            Id = id;
            QuestionId = questionId;
            Text = text;
          
        }

        public int QuestionId { get; private set; }
        public string Text { get; private set; }
     
      
    }
}