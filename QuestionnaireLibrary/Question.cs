using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLibrary
{
    internal class Question
    {

        private List<Question> possibleAnswer;

        // getters and setters
        public string Text { get; set; }

        public string ImageUrl { get; set; }
        

        

        

        public void AddPossibleAnswer(Answer answer)
        {
            possibleAnswer.Add(answer);
        }
    }
}
