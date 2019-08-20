using System;
using System.Net;
using ProjectClassLibrary;

/**********
 The  project will count the number of instances of each word in a 
 text file for given File ( Web Link)

  The solution  has test project to test word count method
 *********/
public class WordCounter
{
	static void Main()
	{
		
		using (WebClient client = new WebClient())
		{
			//Given Top Selection Criteria
			int topselection = 10;

			//Given Web Link to get the Text Data
			string weblink = "https://archive.org/stream/TheLordOfTheRing1TheFellowshipOfTheRing/The+Lord+Of+The+Ring+1-The+Fellowship+Of+The+Ring_djvu.txt";

			//Download the Html Data for the Given Web Link
			string texthtml = client.DownloadString(weblink);

			if (texthtml == null)
			{

				Console.WriteLine("No Data found  to process....");
			}
			
				
			else
			{
				//Get the Top Words as a Dictionary Value
				var worddict = WordProcess.ProcessWordCount(texthtml, topselection);

				if (worddict != null)

				{
					//Display Top Occurance from the Word Dictionary
					foreach (var word in worddict)
					{
						Console.WriteLine("{0} {1}", word.Key, word.Value);
					}

				}
			}
		}


	}

}
