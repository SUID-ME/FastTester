using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.Logic.Models
{
    public class TestContent
    {
        public TestContent()
        {
            this.QuestionItems = new List<QuestionItem> { };
        }

        public List<QuestionItem> QuestionItems { get; set; }
    }
}
