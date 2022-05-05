namespace TestSolving
{
	class TestLogic : CMDInterface
	{
		public TestLogic(TestContent testContent)
		{
			_questions = testContent.Questions;
		}

		public void StartTesting()
		{
			Shuffle<QuestionContent>(_questions);
			foreach (var question in _questions)
			{
				Console.Clear();
				Shuffle<AnswerContent>(question.Answers);
				_current_question = question;
				_print_question();
				List<int> userAnswerList = new List<int>();
				string? userAnswer = "";
				do
				{
					userAnswer = Console.ReadLine();

					if (userAnswer == "!exit")
					{
						return;
					}

				} while (parseAnswer(userAnswer, question.Answers.Count, userAnswerList) == false);

				bool answerIsRight = _check_user_answer(question, userAnswerList);

				_print_colored_ansver(userAnswerList);

				if (answerIsRight == true)
				{
					Console.WriteLine("Правильно :3");
					++_right_answers_num;
				} else
				{
					Console.WriteLine("Неверно :P");
					//_print_right_answers(question);
				}


				++_questions_num;
				Console.ReadKey();
			}
		}

		public void PrintTestResult()
		{
			Console.Clear();
			float successProcent;
			if (_questions_num != 0)
			{
				successProcent = (_right_answers_num / _questions_num) * 100;
			} else
			{
				successProcent = 0;
			}
			
			Console.WriteLine("Успешность ответов: " + Math.Ceiling(successProcent) + "%");
			Console.WriteLine("Количество правильных ответов: " + _right_answers_num + "/" + _questions_num);
			Console.ReadKey();
		}

		private void _print_right_answers(QuestionContent question)
		{
			Console.Write("Верный ответ: ");

			string? answerNumsOut = "";
			int answerNum = 1;

			foreach (var answer in question.Answers)
			{
				if (answer.IsTrue == true)
				{
					answerNumsOut += answerNum + ", ";
				}

				++answerNum;
			}

			Console.WriteLine(answerNumsOut.Substring(0, answerNumsOut.Length - 2));

		}

		private bool _check_user_answer(QuestionContent question, List<int> answers)
		{
			List<AnswerContent> answerList = question.Answers;

			int answerIndex = 1;
			foreach (AnswerContent answer in answerList)
			{
				if (answer.IsTrue == false)
				{
					foreach (var answerValue in answers)
					{
						if (answerIndex == answerValue)
						{
							return false;
						}
					}
				} else
				{
					bool answerIsRight = false;
					foreach (var answerValue in answers)
					{
						if (answerValue == answerIndex)
						{
							answerIsRight = true;
							break;
						}
					}

					if (answerIsRight == false)
					{
						return false;
					} 
				}

				++answerIndex;
			}

			return true;
		}

		private void _print_colored_ansver(List<int> answers)
		{
			Console.Clear();
			Console.WriteLine("		" + (_questions_num + 1) + "/" + _questions.Count + ": " + _current_question.Question);
			Console.WriteLine("=========================================================");

			int answerIndex = 1;
			foreach (var answer in _current_question.Answers)
			{
				if (answer.IsTrue == true)
				{
					Console.BackgroundColor = ConsoleColor.Green;
					Console.ForegroundColor = ConsoleColor.Black;
				} else
				{
					foreach (var answerValue in answers)
					{
						if (answerValue == answerIndex)
						{
							Console.BackgroundColor= ConsoleColor.Red;
							Console.ForegroundColor = ConsoleColor.Black;
						}
					}
				}

				Console.WriteLine(answerIndex++ + ")" + answer.Answer);
				Console.ResetColor();
			}
			Console.WriteLine("=========================================================");
		}

		private void _print_question()
		{
			Console.WriteLine("		" + (_questions_num + 1) + "/" + _questions.Count + ": " + _current_question.Question);
			Console.WriteLine("=========================================================");

			int answerIndex = 0;
			foreach (var answer in _current_question.Answers)
			{
				Console.WriteLine(++answerIndex + ")" + answer.Answer);
			}
			Console.WriteLine("=========================================================");
			Console.Write("Ваш ответ: ");
		}

		protected override void reprint()
		{
			Console.Clear();
			Console.WriteLine("										Такого варианта нет)");
			_print_question();
		}

		public void Shuffle<Type>(List<Type> contents)
		{
			Random random = new Random();

			for (int i = contents.Count - 1; i >= 1; i--)
			{
				int j = random.Next(i + 1);
				// обменять значения data[j] и data[i]
				var temp = contents[j];
				contents[j] = contents[i];
				contents[i] = temp;
			}
		}

		private List<QuestionContent> _questions;

		private QuestionContent _current_question;

		private float _right_answers_num = 0;

		private float _questions_num = 0;
	}
}