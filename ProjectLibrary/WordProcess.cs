using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ProjectClassLibrary
{
    public class WordProcess
    {

		public static Dictionary<string,int> ProcessWordCount(string htmldata, int top)
		{
					
				//remove any html elements
				htmldata = RemoveHtmlTags(htmldata);
				//split list into keywords by space and other characters
				string[] words = htmldata.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
				//Convert to List of strings
				List<string> list = words.ToList();
				//Let us remove any non alphabet characters
				var onlyAlphabetRegEx = new Regex(@"^[A-z]+$");
				list = list.Where(f => onlyAlphabetRegEx.IsMatch(f)).ToList();
				//Apply distict keywords by key and count, and then order by count and take top 10
				var topkeywordsdict = list.GroupBy(x => x).OrderByDescending(x => x.Count()).Take(top).ToDictionary(y=>y.Key, y=>y.Count());
				return topkeywordsdict;
				
		}
		
		private static string RemoveHtmlTags(string html)
		{
			string htmlRemoved = Regex.Replace(html, @"<script[^>]*>[\s\S]*?</script>|<[^>]+>| ", " ").Trim();
			string normalised = Regex.Replace(htmlRemoved, @"\s{2,}", " ");
			return normalised;
		}

	}
}
