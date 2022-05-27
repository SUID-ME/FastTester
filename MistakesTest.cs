namespace TestSolving
{
	class MistakesTest : TestLogic
	{
		public MistakesTest()
		{
			questions = new List<QuestionContent>();
			_for_rewrite_content = new List<QuestionContent>();
		}
		public void WorkOnBugs()
		{
			_for_rewrite_content = questions.ToList();
			testingProcess();
			questions.Clear();
			questions = _for_rewrite_content.ToList();
		}

		public List<QuestionContent> Questions
		{
			get { return questions; }
		}

		protected override void onRightAnswer()
		{
			_for_rewrite_content.Remove(current_question);
		}

		private IList<QuestionContent> _for_rewrite_content;
	}
}