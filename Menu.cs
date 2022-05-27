namespace TestSolving
{
	class Menu : CMDInterface		//TODO переделать во что-то приличное
	{
		public Menu()
		{
			_test_filling = new TestFilling();
			_mistake_test = new MistakesTest();
		}

		public void MainMenu()
		{
			Console.Clear();
			_print_main_menu();
			while (true)
			{
				List<int> answerList = new List<int>();
				string? choose = Console.ReadLine();
				if (parseAnswer(choose, 5, answerList) == false)
				{
					continue;
				}

				switch (answerList[0])			//TODO Сделать маштабированны
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
	
							ConstructedTest testLogic = new ConstructedTest(_test_filling.Content, _mistake_test);		//TODO переделать нормально
							testLogic.StartTesting(ref _mistake_test);
							testLogic.PrintTestResult();
							break;
						}

					case 3:
						{
							_mistake_test.WorkOnBugs();
							_mistake_test.PrintTestResult();
							break;
						}

					case 4:
						{
							Console.Clear();
							Console.WriteLine("Используйте команду '!end' во время заполнения вопросов, чтобы закончить заолнение");
							Console.WriteLine("Используйте команду '!exit' во время решения вопросов, чтобы выйти в гланое меню");
							Console.ReadKey();
							break;
						}

					case 5:
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
			Console.WriteLine("3) Работа над ошибками");
			Console.WriteLine("4) Справка");
			Console.WriteLine("5) Выйти");
			Console.WriteLine("================================");
			Console.Write("Выбор: ");
		}

		private TestFilling _test_filling;

		private MistakesTest _mistake_test;
	}
}