using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input12t.txt");
			int sum = 0;
			foreach(string line in lines)
			{
				string springs = line.Split()[0];
				List<int> cifre = line.Split()[1].Split(',').Select(int.Parse).ToList();
				List<int> placi = new List<int>();
				int ind = 0;
				int cnt = 0;
				int innerSum = 1;
				for (int i = 0; i < springs.Length; i++)
				{
					if(springs[i] == '?')
						cnt++;
					if (springs[i] == '#')
					{
						int plac = cnt + 1;
						int cifr = 1;
						if (plac >= cifre[ind])
						{
							int curSum = 0;
							for (int k = ind; k < cifre.Count; k++)
							{
								if (plac >= curSum + cifre[k] + (curSum > 0 ? 1 : 0))
								{
									if (curSum > 0)
										curSum++;
									curSum += cifre[k];
									cifr++;
								}
								else
								{
									ind = k;
									break;
								}
							}
							innerSum *= Math.Max((plac - curSum) * cifr, 1);
						}
						else
						{
							continue;
						}
					}
					if ((springs[i] == '.' || i == springs.Length - 1) && cnt > 0)
					{
						placi.Add(cnt);
						//Console.WriteLine(cnt);
						cnt = 0;
					}
				}
				/*foreach(int plac in placi)
				{
					int curSum = 0;
					int cifr = 1;
					for(int i = ind; i < cifre.Count; i++)
					{
						if(plac >= curSum + cifre[i] + (curSum > 0? 1:0))
						{
							if (curSum > 0)
								curSum++;
							curSum += cifre[i];
							cifr++;
						}
						else
						{
							ind = i;
							break;
						}
					}
					if(curSum > 0)
					{
						innerSum *= Math.Max((plac - curSum) * cifr, 1);
					}
				}*/
				sum += innerSum;
				Console.WriteLine(innerSum);
				//Console.WriteLine("\n-------------------------------------------");
			}
			Console.WriteLine("final:"+sum);
			Console.ReadLine();
		}
	}
}
