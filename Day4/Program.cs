using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input4.txt");
			long sum = 0;
			Dictionary<int, int> ponovitve = new Dictionary<int, int>();
			for(int i = 0; i < lines.Length; i++)
			{
				ponovitve.Add(i, 0);
			}

			for(int i = 0; i < lines.Length; i++) 
			{
				string line = lines[i];
				int dvopicje = line.IndexOf(':');
				int crta = line.IndexOf('|');
				string winningStr = line.Substring(dvopicje + 1, crta - dvopicje - 1);
				string mineStr = line.Substring(crta + 1);
				List<int> winning = winningStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
				List<int> mine = mineStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
				var won = mine.Intersect(winning);
				for (int k = 0; k <= ponovitve[i]; k++)
				{
					int curWinnings = 0;

					for (int l = 1; l <= won.Count(); l++)
					{
						if (curWinnings == 0)
						{
							curWinnings = 1;
						}
						else
						{
							curWinnings *= 2;
						}
						if (i + l < lines.Length)
							ponovitve[i + l]++;

					}
					sum++;
				}
			}
			Console.WriteLine(sum);
			Console.ReadLine();
		}
	}
}
