using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.Logic.Models
{
    public class TestContent
    {
        public bool IsTestComplete { get; private set; }

        private void _updateIsTestComplete()
        {
            IsTestComplete = (this.QuestionItems != null && this.QuestionItems.Count > 0);
        }

        public TestContent()
        {
            this.QuestionItems = new List<QuestionItem> { };
            _testName = "TestName";
        }

        public string TestName { 
            get { return _testName; } 
            set { 
                _testName = value;
                _updateIsTestComplete();
            }
        }

        private string _testName;

        public List<QuestionItem> QuestionItems { get; set; }
    }
}
