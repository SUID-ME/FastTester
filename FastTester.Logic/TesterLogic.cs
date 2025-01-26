using FastTester.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.Logic
{
    public class TesterLogic
    {
        public TesterLogic() { 
            _parser = new TestParser();
            _tests = new List<TestContent>();
        }

        public async Task TestParse(string text)
        {
            //return _parser.Parse(text);
            await Task.Run(() => _parser.Parse(text));
        }

        public void AddTest(TestContent content)
        {
            _tests.Add(content);
        }
        
        public void SaveTests()
        {

        }

        public TestParser Parser => _parser;

        private TestParser _parser;
        private List<TestContent> _tests;
    }
}
