using NUnit.Framework;
using QuestionaryApp.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace QuestionaryApp.UnitTest
{
    public class Tests
    {
        private Question _question;

        [SetUp]
        public void Setup()
        {
            var choices = new List<Choice>()
            {
                new Choice(1,1,"6"),
                new Choice(2,1,"9"),
                new Choice(3,1,"12"),

              

            };
            _question = new Question(choices);
          

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(1,2,3)]
        public void IsValidAnswer_Accepted(params int[] value)
        {
            _question.Answer(new Answer(_question.Id, value, "Test"));
           
            Assert.IsTrue(_question.Answers.Count() == 1," Answer should be added");
        }
        [TestCase(5)]
        [TestCase(1,5)]
        public void IsInValidAnswer_Rejected(params int[] value)
        {
            _question.Answer(new Answer(_question.Id, value, "Test"));

            Assert.IsFalse(_question.Answers.Count() == 1, "Answer should not be added");
        }
    }
}