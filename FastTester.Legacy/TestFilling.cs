namespace FastTestLegacy
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

				if (question[0] == '!')
				{
					continue;
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

					//Console.WriteLine(answerTxt.Length);

					if (answerTxt.Length > 2 && (answerTxt[1] == '.' || answerTxt[1] == ')'))
					{
						answerTxt = answerTxt.Remove(0, 2);
					}

					answerContent.Answer = answerTxt;
					answers.Add(answerContent);
				}

				_content.AddQuestion(question, answers);
			}
		}

		public void FillContent2()
		{
			Console.Clear();
			_content.ClearContent();
			Console.WriteLine("Введите путь к файлу");
			String? filepath = Console.ReadLine();
			if (String.IsNullOrEmpty(filepath))
			{
				_error("Путь не введен");
				return;
			}

			if (!File.Exists(filepath))
			{
				_error("Файл не существует");
				return;
			}

			bool isQuestionEnd = true;
			String question = "";
			List<AnswerContent> answers = new List<AnswerContent>(); 
			AnswerContent answerContent = new AnswerContent();

			foreach (string line in System.IO.File.ReadLines(filepath))
			{
				if (isQuestionEnd && String.IsNullOrEmpty(line) == false)
				{
					question = line;
					isQuestionEnd = false;
					continue;
				} else if (isQuestionEnd == false)
				{
					if (String.IsNullOrEmpty(line) == true)
					{
						if (answers.Count > 0)
						{
							_content.AddQuestion(question, answers);
						}
						
						answers = new List<AnswerContent>();
						isQuestionEnd = true;
						continue;
					}

					String currentAnswer = "";
					if (line[0] == '~')
					{
						currentAnswer = line.Substring(1);
						answerContent.IsTrue = true;
					} else
					{
						currentAnswer = line;
					}

					currentAnswer = currentAnswer.TrimStart(_numbering_symbols);

					if (String.IsNullOrEmpty(currentAnswer) == false)
					{
                        answerContent.Answer = currentAnswer;
                        answers.Add(answerContent);
                    }

					answerContent = new AnswerContent();
				}
			}

			Console.WriteLine("Тест создан. Количество элементов в тесте = " + _content.Questions.Count);
			Console.ReadKey();
		}
		
		public TestContent Content { get { return _content; } }

		private TestContent _content;

		private void _error(string info)
		{
			Console.WriteLine("Error: " + info);
			Console.ReadKey();
		}

		private char[] _numbering_symbols = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ', '.', ')' };
    }
}