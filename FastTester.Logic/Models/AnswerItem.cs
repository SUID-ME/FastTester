using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastTester.Logic.Models
{
    public class AnswerItem
    {
        public AnswerItem(string textContent = "DefaultAnswer") { 
            this.TextContent = textContent;
        }

        public string TextContent {  get; set; }
        public bool IsRight { get; set; }
    }
}
