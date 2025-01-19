namespace FastTestLegacy
{
	class CMDInterface
	{
		protected bool parseAnswer(string? answer, int answerSize, List<int> retAnswerList)
		{
			if (String.IsNullOrEmpty(answer) == true)
			{
				reprint();
				return false;
			}

			answer = answer.Replace(" ", "");

			string[] userAnswerArray = answer.Split(',');

			foreach (string userAnswer in userAnswerArray)
			{
				if (String.IsNullOrEmpty(userAnswer) == true)
				{
					continue;
				}

				int answerPart;
				bool success = int.TryParse(userAnswer, out answerPart);
				if (success == true && (answerPart <= answerSize && answerPart > 0))
				{
					retAnswerList.Add(answerPart);
				}
				else
				{
					retAnswerList.Clear();
					reprint();
					return false;
				}

			}

			return true;
		}

		protected virtual void reprint()
		{
			return;
		}
	}
}