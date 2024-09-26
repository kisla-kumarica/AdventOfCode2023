using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Day1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input1.txt");
			int[] vals = new int[lines.Length];
			string[] cifre = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
			for(int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				string val = "";
				char last = '0';
				for (int k = 0; k < line.Length; k++)
				{
					if (char.IsDigit(line[k]) && val == "")
						val += line[k];
					else if (char.IsDigit(line[k]))
						last = line[k];
					else
					{
						for(int l = 0; l < cifre.Length; l++)
						{
							if (line.IndexOf(cifre[l], k) == k)
							{
								if(val == "")
									val += (char)(l + 1 + 48);
								else
									last = (char)(l+1+48);
								break;
							}
						}
					}
				}
				if (last == '0')
					last = val[0];
				val += last;
				vals[i] = int.Parse(val);
			}
			Console.WriteLine(vals.Sum());
			Console.ReadLine();
		}
	}
}
