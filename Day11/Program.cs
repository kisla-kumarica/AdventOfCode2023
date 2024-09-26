using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input11.txt").ToList();
			List<string> lines2 = new List<string>(lines);
			Dictionary<int, int> insertedCols = new Dictionary<int, int>();
			Dictionary<int, int> insertedRows = new Dictionary<int, int>();
			for (int i = 0; i < lines2.Count; i++)
			{
				string line = lines2[i];
				if (line == new string('.', line.Length))
				{
					/*for(int n = 0; n < 1000000; n++)
						lines2.Insert(i, new string('.', lines2.First().Length));
					insertedLine = i;*/
					insertedRows.Add(i, 1000000-1);
				}
				if (i < line.Length && lines2.All(s => s[i] == '.'))
				{
					/*for (int n = 0; n < 1000000; n++)
						lines2 = lines2.Select(s => s.Insert(i, ".")).ToList();
					insertedCol = i;*/
					insertedCols.Add(i, 1000000-1);
				}
			}
			List<Tuple<int, int>> pos = new List<Tuple<int, int>>();

			int x = 0;
			int y = 0;
			for (int i = 0; i < lines2.Count; i++)
			{
				string line = (string)lines2[i];
				if (insertedRows.ContainsKey(i))
					y += insertedRows[i];
				for (int k = 0; k < line.Length; k++)
				{
					if (insertedCols.ContainsKey(k))
						x += insertedCols[k];

					if (line[k] == '#')
						pos.Add(new Tuple<int, int>(x, y));
					x++;
				}
				y++;
				x = 0;
			}
			long sum = 0;
			for(int i = 0; i < pos.Count; i++)
			{
				for(int k = i; k < pos.Count; k++)
				{
					if (i != k)
					{
						sum += Math.Abs(pos[k].Item1 - pos[i].Item1) + Math.Abs(pos[k].Item2 - pos[i].Item2);
					}
				}
			}
			Console.WriteLine(sum);

			Console.ReadLine();
		}
	}
}
