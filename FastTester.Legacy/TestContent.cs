namespace FastTestLegacy
{
	class TestContent
	{
		public TestContent()
		{
			_questions = new List<QuestionContent>();
		}

		public TestContent(List<QuestionContent> questions)
		{
			_questions = questions;
		}

		public void AddQuestion(string questionTxt, List<AnswerContent> answers)
		{
			QuestionContent questionContent = new QuestionContent();
			questionContent.Question = questionTxt;
			questionContent.Answers = answers;
			questionContent.Number = _questions.Count+1;
			_questions.Add(questionContent);
		}

		public void ClearContent()
		{
			_questions.Clear();
		}

		public List<QuestionContent> Questions { get { return _questions; } }

		private List<QuestionContent> _questions = new List<QuestionContent>();
	}
}