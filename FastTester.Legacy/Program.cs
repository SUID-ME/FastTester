namespace FastTestLegacy
{
	public struct QuestionContent
	{
		public int Number;
		public string Question;
		public List<AnswerContent> Answers;
	}

	public struct AnswerContent
	{
		public string Answer;
		public bool IsTrue;
	}

	class Program
	{

		static void Main(string[] args)
		{
			_encoding_magic();
			
			Menu menu = new Menu();
			menu.MainMenu();
		}

		

		static private void _encoding_magic()
		{
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			var enc1251 = System.Text.Encoding.GetEncoding(1251);

			System.Console.OutputEncoding = System.Text.Encoding.UTF8;
			System.Console.InputEncoding = enc1251;
		}
	}
}