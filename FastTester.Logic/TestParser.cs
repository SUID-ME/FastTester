using FastTester.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.Logic
{
    public class TestParser
    {
        public event Action<TestContent> OnParseComplete;

        public void Parse(string input)
        {
            TestContent testContent = new TestContent();
            QuestionItem question = new QuestionItem();

            bool isQuestionEnd = true;
            var lines = input.Split('\n').Select(s => s.Replace("\r", ""));
            foreach (var line in lines)
            {
                if (isQuestionEnd == false)
                {
                    if (string.IsNullOrWhiteSpace(line) == true && question.Answers.Count > 0)
                    {
                        isQuestionEnd = true;
                        testContent.QuestionItems.Add(question);
                        question = new QuestionItem();
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(line) == false)
                    {
                        addAnswer(question, line);
                    }
                }
                else if (string.IsNullOrEmpty(line) == false)
                {
                    isQuestionEnd = false;
                    question.TextContent = line;
                }
            }
            if (question != null)
            {
                testContent.QuestionItems.Add(question);
            }

            OnParseComplete?.Invoke(testContent);
        }

        private void addAnswer(QuestionItem question, string line)
        {
            AnswerItem answer = new AnswerItem();
            string currentAnswer = "";
            if (line[0] == '~')
            {
                currentAnswer = line.Substring(1);
                answer.IsRight = true;
            }
            else
            {
                currentAnswer = line;
            }

            currentAnswer = currentAnswer.TrimStart(_numbering_symbols);

            if (string.IsNullOrEmpty(currentAnswer) == false)
            {
                answer.TextContent = currentAnswer;
                question.Answers.Add(answer);
            }
        }

        private char[] _numbering_symbols = new char[] {
            '1', '2', '3', '4', '5', '6',
            '7', '8', '9', '0', ' ', '.', ')'
        };
    }
}
