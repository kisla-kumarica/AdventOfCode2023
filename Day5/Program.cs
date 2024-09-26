using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input5.txt");
			List<List<long[]>> maps = new List<List<long[]>>();
			long[] seeds1 = lines.First().Split().Skip(1).Select(i=> long.Parse(i)).ToArray();
			List<long[]> seeds = new List<long[]>();
			for (int i = 0; i < seeds1.Length; i = i + 2)
			{
				seeds.Add(new long[] { seeds1[i], seeds1[i + 1]});
			}

			foreach (string line in lines.Skip(1))
			{
				if (line.Trim() == "")
					maps.Add(new List<long[]>());
				else if (!char.IsLetter(line[0]))
					maps.Last().Add(line.Split().Select(i => long.Parse(i)).ToArray());
			}

			/*for(int l = 0; l < seeds.Count(); l++)
			{
				for(int i = 0; i < maps.Count; i++)
				{
					long seed = seeds[l][0];
					for (int k = 0; k < maps[i].Count; k++)
					{
						if (maps[i][k][1] <=  seed && maps[i][k][1] + maps[i][k][2] > seed)
						{
							seeds[l][0] = seed - maps[i][k][1] + maps[i][k][0];
							break;
						}
					}
				}
			}

			Console.WriteLine(seeds.Select(i => i[0]).Min());
			Console.ReadLine();*/
			for (long l = 0; l < long.MaxValue; l++)
			{
				long val = l;
				for (int i = maps.Count - 1; i >= 0; i--)
				{
					for (int k = 0; k < maps[i].Count; k++)
					{
						if (maps[i][k][0] <= val && maps[i][k][0] + maps[i][k][2] > val)
						{
							val = val - maps[i][k][0] + maps[i][k][1];
							break;
						}
					}
				}
				if (seeds.Where(k => val >= k[0] && val < k[0] + k[1]).Any())
				{
					Console.WriteLine(l);
					Console.ReadLine();
				}
			}
		}
	}
}
