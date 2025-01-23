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
        }

        public async Task TestParse(string text)
        {
            //return _parser.Parse(text);
            await Task.Run(() => _parser.Parse(text));
        }

        private TestParser _parser;
    }
}
