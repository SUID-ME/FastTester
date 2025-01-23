using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.Logic.Models
{
    public class QuestionItem
    {
        public QuestionItem(String textContent = "DefaultQuestion")
        {
            Answers = new List<AnswerItem>();
            TextContent = textContent;
        }

        public QuestionItem(List<AnswerItem> answerItems, String textContent = "DefaultQuestion")
        {

            if (answerItems == null)
            {
                answerItems = new List<AnswerItem>();
            }
            else
            {
                Answers = answerItems;
            }
            
            TextContent = textContent;
        }

        public void SetAnswers(List<AnswerItem> answerItems)
        {
            Answers = Answers;
        }

        public string TextContent { get; set; }
        public List<AnswerItem> Answers { get; set; }
    }
}
