namespace TestSolving
{
	class Menu : CMDInterface
	{
		public Menu()
		{
			_test_filling = new TestFilling();
		}

		public void MainMenu()
		{
			Console.Clear();
			_print_main_menu();
			while (true)
			{
				List<int> answerList = new List<int>();
				string? choose = Console.ReadLine();
				if (parseAnswer(choose, 4, answerList) == false)
				{
					continue;
				}

				switch (answerList[0])
				{
					case 1:
						{
							if (_test_filling != null)
							{
								_test_filling.FillContent();
							}
							break;
						}

					case 2:
						{
							if (_test_filling == null)
							{
								continue;
							}
	
							TestLogic testLogic = new TestLogic(_test_filling.Content);
							testLogic.StartTesting();
							testLogic.PrintTestResult();
							break;
						}

					case 3:
						{
							Console.Clear();
							Console.WriteLine("Используйте команду '!end' во время заполнения вопросов, чтобы закончить заолнение");
							Console.WriteLine("Используйте команду '!exit' во время решения вопросов, чтобы выйти в гланое меню");
							Console.ReadKey();
							break;
						}

					case 4:
						{
							return;
						}

					default:
						break;
				}

				Console.Clear();
				_print_main_menu();
			}
		}

		protected override void reprint()
		{
			Console.Clear();
			Console.WriteLine("										Такого варианта нет)");
			_print_main_menu();
		}

		private void _print_main_menu()
		{
			Console.WriteLine("--------------МЕНЮ--------------");
			Console.WriteLine("1) Создать тест");
			Console.WriteLine("2) Пройти тест");
			Console.WriteLine("3) Справка");
			Console.WriteLine("4) Выйти");
			Console.WriteLine("================================");
			Console.Write("Выбор: ");
		}

		private TestFilling _test_filling;
	}
}