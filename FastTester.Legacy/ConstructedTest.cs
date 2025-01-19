namespace FastTestLegacy
{
	class ConstructedTest : TestLogic
	{
		public ConstructedTest(TestContent testContent, MistakesTest mistakesTest)
		{
			questions = testContent.Questions;
			_mistakes = mistakesTest;
		}

		public void StartTesting(ref MistakesTest mistakes)
		{
			testingProcess();
			mistakes = _mistakes;
		}

		protected override void onWrongAnswer()
		{
			bool need_add = true;

			foreach (var answer in _mistakes.Questions)
			{
				if (answer.Number == current_question.Number && answer.Question == current_question.Question)
				{
					need_add = false;
					break;
				}
			}

			if (need_add == true)
			{
				_mistakes.Add(current_question);
			}
			
		}

		private MistakesTest _mistakes;
	}
}