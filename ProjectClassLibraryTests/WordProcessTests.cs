using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectClassLibrary.Tests
{
	[TestClass()]

	public class WordProcessTests
	{
			
		//Test word count
		[TestMethod()]
		public void ProcessSampleWordCountTest()
		{
			string str = "Hello World! Hello! Hello World Masters";
			//Select Top Criteria
			int topselection = 1;
			//Get the Top Words as a Dictionary
			var worddict = WordProcess.ProcessWordCount(str, topselection);
			var countvalue = worddict["Hello"];
			Assert.AreEqual(countvalue, 3);

		}

	
	}
}