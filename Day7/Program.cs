using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
	internal class Program
	{
		static Dictionary<char, char> subs = new Dictionary<char, char>()
		{
			{'A', 'E' },
			{'T', 'A' },
			{'Q', 'C' },
			{'K', 'D' },
			{'J', '0' }
		};
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input7.txt");
			for (int i = 0; i < lines.Count(); i++) 
			{
				foreach(char c in subs.Keys)
					lines[i] = lines[i].Replace(c, subs[c]);
			}
			List<string> cards = new List<string>();
			List<int> bets = new List<int>();
			List<int> scores = new List<int>();
			int[] ranks = new int[lines.Length];
			long result = 0;
			foreach (string line in lines)
			{
				string karte = line.Substring(0, 5);
				cards.Add(karte);
				int jokers = 0;
				bets.Add(int.Parse(line.Substring(5).Trim()));
				Dictionary<char, int> hand = new Dictionary<char, int>();
				foreach(char c in line.Substring(0,5))
				{
					if (hand.ContainsKey(c)) hand[c]++;
					else hand.Add(c, 1);
					if (c == '0')
						jokers++;
				}
				int min = 7;
				int pari = 0;
				if(karte == "00000")
					min = 1;
				hand = hand.OrderByDescending(i => i.Value).ToDictionary(x => x.Key, x => x.Value);
				for (int l = 0; l < hand.Keys.Count(); l++)
				{
					int k = hand.ElementAt(l).Value;
					if (k >= 5 - jokers && hand.ElementAt(l).Key != '0')
					{
						if (k < 5)
							jokers -= 5 - k;
						min = 1;
					}
					else if (k >= 4 - jokers && hand.ElementAt(l).Key != '0' && min > 2)
					{
						if (k < 4)
							jokers -= 4 - k;
						min = 2;
					}
					else if (k >= 3 - jokers && min > 4 && hand.ElementAt(l).Key != '0')
					{
						if (k < 3)
							jokers -= 3 - k;
						min = 4;
					}
					else if(hand.ElementAt(l).Key != '0')
					{
						if (k == 2)
						{
							pari++;
						}
						else if (k == 1 && jokers > 0)
						{
							pari++;
							jokers--;
						}
					}
				}
				if (min == 4 && pari == 1)
					min = 3;
				else if (pari == 2 && min > 5)
					min = 5;
				else if (pari == 1 && min > 6)
					min = 6;
				else if (min > 7) min = 7;
				scores.Add(min);
			}
			var sorted = scores
				.Select((x, i) => new KeyValuePair<int, int>(x, i))
				.OrderBy(x => x.Key)
				.ThenByDescending(x => cards[x.Value])
				.Reverse()
				.ToList();

			List<int> idx = sorted.Select(x => x.Value).ToList();

			for(int i = 1; i <= idx.Count; i++)
			{
				result += bets[idx[i - 1]] * i;
				Console.WriteLine(cards[idx[i - 1]] + "\t" + sorted[i-1].Key);
			}
			Console.WriteLine(result);


			Console.ReadLine();
		}

	}
}
