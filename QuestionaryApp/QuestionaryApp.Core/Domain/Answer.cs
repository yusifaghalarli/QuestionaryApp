

using System.Collections.Generic;
using System.Linq;

namespace QuestionaryApp.Core.Domain
{
    public class Answer:Entity
    {
        //Ef Core
        private Answer()
        {

        }

        public Answer(int questionId,int[] selectedChoiceIds, string userName)
        {
            if (selectedChoiceIds is null)
            {
                throw new System.ArgumentNullException(nameof(selectedChoiceIds));
            }

            SeletedChoices = selectedChoiceIds.Select(x => new SelectedChoice(this.Id,x)).ToList();
            QuestionId = questionId;
            UserName = userName;
        }

        public int QuestionId { get; private set; }
        public List<SelectedChoice> SeletedChoices { get; private set; }
        public string UserName { get; private set; }
    }
}
