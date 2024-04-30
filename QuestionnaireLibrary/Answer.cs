using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLibrary
{
    internal class Answer
    {

        public string text = null;
        public bool isCorrect = false;

        public Answer(string text, bool isCorrect)
        {
            this.text = text;
            this.isCorrect = isCorrect;
        }

        public override string ToString()
        {
            return text + "is " +isCorrect;
        }
    }
}
