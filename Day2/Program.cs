using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;

namespace Day2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input2.txt");
			int sum = 0;
			for(int i = 0; i < lines.Length; i++)
			{
				string line = lines[i].Substring(lines[i].IndexOf(':') + 1);

				string val = "";
				string color = "";
				int maxRed = 0; 
				int maxGreen = 0;
				int maxBlue = 0;
				for (int k = 0; k < line.Length; k++)
				{
					if (char.IsDigit(line[k]))
						val += line[k];
					else if (line[k] != ',' && line[k] != ' ' && line[k] != ';')
					{
						color += line[k];
					}
					if(line[k] == ',' || line[k] == ';' || k == line.Length - 1)
					{
						if(color == "green" && int.Parse(val) > maxGreen)
							maxGreen = int.Parse(val);
						if (color == "red" && int.Parse(val) > maxRed)
							maxRed = int.Parse(val);
						if (color == "blue" && int.Parse(val) > maxBlue)
							maxBlue = int.Parse(val);
						color = "";
						val = "";
					}
					/*if(k == line.Length - 1)
					{
						sum += i + 1;
					}*/

					if (k == line.Length - 1)
					{
						sum += maxGreen * maxRed * maxBlue;
					}
				}
			}
			Console.WriteLine(sum.ToString());
			Console.ReadLine();
		}
	}
}
