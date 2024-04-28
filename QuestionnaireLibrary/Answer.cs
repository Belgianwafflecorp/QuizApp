using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLibrary
{
    internal class Answer
    {

        /*
        + Text : string 
        + IsCorrect : bool

        + Answer(text: string, IsCorrect: bool)
        + ToString() : string
        */

        public string text = null;
        public bool isCorrect = false;

        public Answer(string text, bool isCorrect)
        {
            this.text = Text;
            this.isCorrect = IsCorrect;
        }

        public override string ToString()
        {
            return Text + "is " + IsCorrect;
        }
    }
}
