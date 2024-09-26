using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input13.txt");
			List<List<string>> mirrors = new List<List<string>>();
			mirrors.Add(new List<string>());
			foreach (string line in lines)
			{
				if(line != "")
					mirrors.Last().Add(line);
				else
					mirrors.Add(new List<string>());
			}
			long sum = 0;
			for (int k = 0; k < mirrors.Count; k++)
			{
				int firstIndVer = 0;
				int firstIndHor = 0;
				int firstIndVerReal = 0;
				int firstIndHorReal = 0;
				int ind = 0;
				bool najden = false;
				int lenVer = 0;
				int lenHor = 0;
				int lenVerReal = 0;
				int lenHorReal = 0;
				List<string> curMirror = mirrors[k];
				bool smudgeUsed = false;
				int indexUsed = -1;
				string prevString = "";
				char[] prevChars = new char[curMirror.First().Length];

				for (int i = 0; i < curMirror.First().Length; i++)
				{
					if (!najden)
						ind = i - 1;
					if (i > 0 && ind >= 0 && compareChars(curMirror.Select(l => l[i]), curMirror.Select(l => l[ind]), ref smudgeUsed, out bool used))
					{
						if(used)
						{
							indexUsed = ind;
							prevChars = curMirror.Select(l => l[ind]).ToArray();
						}
						curMirror = curMirror.Select((l, f) =>
						{
							StringBuilder sb = new StringBuilder(l);
							sb[ind] = curMirror[f][i];
							return sb.ToString();
						}).ToList();
						lenVer++;
						if (i == ind + 1)
							firstIndVer = i - 1;
						if ((i == curMirror.First().Length - 1 || ind == 0) && smudgeUsed)
						{
							lenVerReal = lenVer;
							firstIndVerReal = firstIndVer;
							break;
						}
						else
							ind--;
						najden = true;
						if ((ind == -1 && i + 1 < curMirror.First().Length))
						{
							smudgeUsed = false;
							if(indexUsed > -1)
							{
								curMirror = curMirror.Select((l, f) =>
								{
									StringBuilder sb = new StringBuilder(l);
									sb[indexUsed] = prevChars[f];
									return sb.ToString();
								}).ToList();
								indexUsed = -1;
							}
							if(smudgeUsed)
							firstIndVer = 0;
							lenVer = 0;
							ind = i - 1;
							najden = false;
						}
					}
					else
					{
						najden = false;
						smudgeUsed = false;
						if (indexUsed > -1)
						{
							curMirror = curMirror.Select((l, f) =>
							{
								StringBuilder sb = new StringBuilder(l);
								sb[indexUsed] = prevChars[f];
								return sb.ToString();
							}).ToList();
							indexUsed = -1;
						}
					}
				}
				ind = 0;
				najden = false;
				smudgeUsed = false;
				if (indexUsed > -1)
				{
					curMirror = curMirror.Select((l, f) =>
					{
						StringBuilder sb = new StringBuilder(l);
						sb[indexUsed] = prevChars[f];
						return sb.ToString();
					}).ToList();
					indexUsed = -1;
				}
				for (int i = 0; i < curMirror.Count(); i++)
				{
					if (!najden)
						ind = i - 1;
					if (ind >= 0 && i > 0 && compareStrings(curMirror[i], curMirror[ind], ref smudgeUsed, out bool used))
					{
						if (used)
						{
							indexUsed = ind;
							prevString = curMirror[ind];
						}
						curMirror[ind] = curMirror[i];
						lenHor++;
						if (i == ind + 1)
							firstIndHor = i - 1;
						if ((i == curMirror.Count() - 1 || ind == 0) && smudgeUsed)
						{
							lenHorReal = lenHor;
							firstIndHorReal = firstIndHor;
							break;
						}
						else
							ind--;
						najden = true;
						if (ind == -1 && i + 1 < curMirror.Count())
						{
							if(indexUsed > -1)
							{
								curMirror[indexUsed] = prevString;
								indexUsed = -1;
							}
							smudgeUsed = false;
							firstIndHor = 0;
							lenHor = 0;
							ind = i - 1;
							najden = false;
						}
					}
					else
					{
						najden = false;
						if (indexUsed > -1)
						{
							curMirror[indexUsed] = prevString;
							indexUsed = -1;
						}
						smudgeUsed = false;
					}
				}


				if (lenVerReal > lenHorReal /*&& firstIndVerReal != 0*/)
					sum +=  (firstIndVerReal + 1);
				else if(lenVerReal < lenHorReal)
					sum += 100 * (firstIndHorReal + 1);
				else
					Console.WriteLine(k);  //te zracuni rocno :>
			}
			Console.WriteLine(sum);
			Console.ReadLine();
		}

		public static bool compareChars(IEnumerable<char> chars1, IEnumerable<char> chars2, ref bool smudgeUsed, out bool used)
		{
			int numEqual = 0;
			used = false;
			for(int i = 0; i < chars1.Count(); i++)
			{
				if (chars1.ElementAt(i) == chars2.ElementAt(i))
					numEqual++;
			}
			if(numEqual == chars1.Count() - 1 && !smudgeUsed)
			{
				used = true;
				smudgeUsed = true;
				numEqual++;
			}
			return numEqual == chars1.Count();
		}

		public static bool compareStrings(string s1, string s2, ref bool smudgeUsed, out bool used)
		{
			int numEqual = 0;
			used = false;
			for (int i = 0; i < s1.Length; i++)
			{
				if (s1[i] == s2[i])
					numEqual++;
			}
			if (numEqual == s1.Count() - 1 && !smudgeUsed)
			{
				used = true;
				smudgeUsed = true;
				numEqual++;
			}
			return numEqual == s1.Length;
		}
	}
}
