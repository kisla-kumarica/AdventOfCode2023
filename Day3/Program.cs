using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input3.txt");
			int sum = 0;
			for(int i = 0; i < lines.Length; i++)
			{
				string currline = lines[i];
				string prevLine = "", nextLine = "";
				string val = "";
				if(i > 0) 
					prevLine = lines[i - 1];
				if(i < lines.Length - 1)
					nextLine = lines[i + 1];

				for(int k = 0; k < currline.Length; k++) 
				{
					if (currline[k] == '*')
					{
						List<int> vals = new List<int>();
						if (k > 0 && char.IsDigit(currline[k - 1]))
							vals.Add(findNumber(currline, k - 1));
						if (k < currline.Length - 1 && char.IsDigit(currline[k + 1]))
							vals.Add(findNumber(currline, k + 1));

						bool prevLineTerminated = true;
						bool nextLineTerminated = true;

						for (int l = k - 1; l <= k + 1; l++)
						{
							if (l >= 0 && l < prevLine.Length)
							{
								if (char.IsDigit(prevLine[l]) && prevLineTerminated)
								{
									vals.Add(findNumber(prevLine, l));
									prevLineTerminated = false;
								}
								else if(!char.IsDigit(prevLine[l]))
									prevLineTerminated = true;
							}
							if (l >= 0 && l < nextLine.Length)
							{
								if (char.IsDigit(nextLine[l]) && nextLineTerminated)
								{
									vals.Add(findNumber(nextLine, l));
									nextLineTerminated = false;
								}
								else if (!char.IsDigit(nextLine[l]))
									nextLineTerminated = true;
							}
						}
						if(vals.Count >= 2)
							sum += vals.Aggregate((a, x) => a * x); ;
					}
					/*if (char.IsDigit(currline[k]))
					{
						val += currline[k];
					}
					if((!char.IsDigit(currline[k]) || (char.IsDigit(currline[k]) && k == currline.Length - 1)) && val != "")
					{
						if((k - val.Length - 1 >= 0 && isSymbol(currline[k - val.Length - (char.IsDigit(currline[k])?0:1)])) ||
							isSymbol(currline[k]))
						{
							sum += int.Parse(val);
						}
						else
						{
							for(int l = k - val.Length - 1; l <= k; l++)
							{
								if(l >= 0 && l < prevLine.Length && isSymbol(prevLine[l]))
								{
									sum += int.Parse(val);
									break;
								}
								else if (l >= 0 && l < nextLine.Length && isSymbol(nextLine[l]))
								{
									sum += int.Parse(val);
									break;
								}
							}
						}
						val = "";
					}*/
				}
			}

			Console.WriteLine(sum.ToString());
			Console.ReadLine();
		}
		static int findNumber(string s, int index)
		{
			string val = s[index].ToString();
			bool konecLevo = index - 1 < 0, konecDesno = index + 1 >= s.Length;
			for(int i = 1; i < s.Length; i++) 
			{ 
				if(!konecLevo && index - i > 0)
				{
					if (char.IsDigit(s[index - i]))
						val = s[index - i] + val;
					else konecLevo = true;
				}
				if (!konecDesno && index + i < s.Length)
				{
					if (char.IsDigit(s[index + i]))
						val = val + s[index + i];
					else konecDesno = true;
				}
				if (konecLevo && konecDesno)
					break;
			}
			return int.Parse(val);
		}
		static bool isSymbol(char c)
		{
			return c != '.' && !char.IsDigit(c);
		}
	}
}
