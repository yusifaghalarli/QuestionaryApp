using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionaryApp.Core.Domain
{
    public class SelectedChoice:Entity
    {
        private SelectedChoice()
        {

        }
        public int AnswerId { get; set; }
        public int ChoiceId { get; set; }

        public SelectedChoice(int answerId, int choiceId)
        {
            AnswerId = answerId;
            ChoiceId = choiceId;
        }
    }
}
