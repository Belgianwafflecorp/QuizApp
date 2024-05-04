using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLibrary
{
    public class Question
    {

        private readonly List<Answer> possibleAnswer = new();

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public List<Answer> Answers { get { return possibleAnswer; } }
        
        // constructor
        public Question(string text)
        {
            Text = text;
        }

        public void Add(Answer answer)
        {
            possibleAnswer.Add(answer);
        }


        public Answer GetAnswer(int index)
        {
            return possibleAnswer[index];
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
