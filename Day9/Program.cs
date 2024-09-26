using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input9.txt");
			long sum = 0;
			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				List<int> list = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
				List<List<int>> diffs = new List<List<int>>() { list };
				while(!list.All(k=>k==0) && list.Count > 0)
				{
					diffs.Add(new List<int>());
					List<int> cur = new List<int>();
					for (int k = 0; k < list.Count; k++)
					{
						int diff = 0;
						if (k < list.Count - 1)
						{
							diff = list[k + 1] - list[k];
							cur.Add(diff);
							diffs.Last().Add(diff);
						}
					}
					list = new List<int>(cur);
				}
				diffs.Last().Insert(0,0);
				int val = 0;
				for(int k = diffs.Count-2; k >=0; k--)
				{
					val = diffs[k].First() - diffs[k + 1].First();
					diffs[k].Insert(0, val);
				}
				sum += diffs.First().First();
				diffs.Clear();
				diffs = null;
			}
			Console.WriteLine(sum);
			Console.ReadLine();
		}
	}
}
