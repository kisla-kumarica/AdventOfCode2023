using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllText("C:\\Users\\PC\\Documents\\AOC\\input15.txt").Split(',').Select(i=>i.Trim()).ToArray();
			int currentValue = 0;
			int sum = 0;
			foreach(string s in lines)
			{
				currentValue = 0;
				for (int i = 0; i < s.Length; i++)
				{
					currentValue += s[i];
					currentValue *= 17;
					currentValue = currentValue % 256;
				}
				Console.WriteLine(s+"\t"+currentValue);
				sum += currentValue;
			}
			Console.WriteLine(sum);
			Console.ReadLine();
		}
	}
}
