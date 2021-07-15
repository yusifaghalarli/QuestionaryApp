
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionaryApp.Core.Domain
{
    public class Question : Entity
    {

        //For EF Core.
        private Question()
        {
            Choices = new List<Choice>();
            Answers = new List<Answer>();
        }

       
        public Question(List<Choice> choices)
        {
            Choices = choices;
            Answers = new List<Answer>();
        }
        // To Seed data to database
        public Question(int id ,string text, bool hasMultiSelect)
        {
            Id = id;
            Text = text;
            HasMultiSelect = hasMultiSelect;
           
            
        }

        public string Text { get; private set; }
        public bool HasMultiSelect { get; private set; }
        public List<Choice> Choices { get; private set; }
        public List<Answer> Answers { get; private set; }

        public void AddChoice(Choice choice)
        {
            if (choice == null)
            {
                throw new ArgumentNullException(nameof(choice));
            }
           
            Choices.Add(choice);
        }

        public void Answer(Answer answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException(nameof(answer));
            }
           
            //Check if given question has ALL selected choices
            var allValidChoices = Choices.Select(x => x.Id)
                                         .Intersect(answer.SeletedChoices.Select(x => x.ChoiceId));
            if (allValidChoices.Count() != answer.SeletedChoices.Count())
                return;
            Answers.Add(answer);

           
            
            
           
        }
    }
}
