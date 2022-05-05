namespace TestSolving
{
	class TestFilling
	{
		public TestFilling()
		{
			_content = new TestContent();
		}

		public void FillContent()
		{
			Console.Clear();
			_content.ClearContent();
			while (true)
			{
				Console.WriteLine("Введите вопрос.");
				string? question = Console.ReadLine();
				
				if (String.IsNullOrEmpty(question))
				{
					//Console.WriteLine("Вопрос не введен.");
					continue;
				}

				if (question == "!end")
				{
					Console.WriteLine("Конец ввода");
					break;
				}

				Console.WriteLine("Введите ответы.");
				List<AnswerContent> answers = new List<AnswerContent>();

				while (true)
				{
					string? answerTxt = Console.ReadLine();

					if (String.IsNullOrEmpty (answerTxt))
					{
						Console.WriteLine("Ответы введены");
						break;
					}

					AnswerContent answerContent = new AnswerContent();

					if (answerTxt[0] == '~')
					{
						answerContent.IsTrue = true;
						answerTxt = answerTxt.Remove(0, 1);
					}

					if (answerTxt[1] == '.' || answerTxt[1] == ')')
					{
						answerTxt = answerTxt.Remove(0, 2);
					}

					answerContent.Answer = answerTxt;
					answers.Add(answerContent);
				}

				_content.AddQuestion(question, answers);
			}
		}

		public TestContent Content { get { return _content; } }

		private TestContent _content;
	}
}