using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input6.txt");
			/*List<int> times = lines[0].Substring(5).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
			List<int> distances = lines[1].Substring(10).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();*/
			List<long> times = new List<long>() { long.Parse(string.Join("",lines[0].Substring(5).Where(i => char.IsDigit(i)))) };
			List<long> distances = new List<long>() { long.Parse(string.Join("", lines[1].Substring(10).Where(i => char.IsDigit(i)))) };
			int sum = 1;
			for(int i = 0; i < times.Count; i++)
			{
				int wins = 0;
				for(int k = 0; k < times[i]; k++)
				{
					int speed = 0;
						speed = k;
					long dist = (times[i] - k) * speed;
					if (dist > distances[i])
						wins++;
				}
				sum *= wins;
			}
			Console.WriteLine(sum);
			Console.ReadLine();
		}
	}
}
