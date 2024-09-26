using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input14.txt");
			long sum = 0;
			for(long i = 0; i < 1000; i++)
			{
				shiftNorth(lines);
				shiftWest(lines);
				shiftSouth(lines);
				shiftEast(lines);
				sum = 0;
				for (int l = 0; l < lines.Length; l++)
				{
					for (int m = 0; m < lines[l].Length; m++)
					{
						if (lines[l][m] == 'O')
							sum += lines.Length - l;
					}
				}
				Console.WriteLine(sum);
			}
			Console.ReadLine();
		}
		public static void shiftNorth(string[] lines)
		{
			for (int i = 0; i < lines.First().Length; i++)
			{
				for (int k = 0; k < lines.Length; k++)
				{
					if (lines[k][i] == 'O')
					{
						for (int l = k - 1; l >= 0; l--)
						{
							if (lines[l][i] == '#' || lines[l][i] == 'O')
								break;
							else
							{
								StringBuilder sb = new StringBuilder(lines[l]);
								sb[i] = 'O';
								lines[l] = sb.ToString();
								sb = new StringBuilder(lines[l + 1]);
								sb[i] = '.';
								lines[l + 1] = sb.ToString();
							}
						}
					}
				}
			}
		}
		public static void shiftSouth(string[] lines)
		{
			for (int i = 0; i < lines.First().Length; i++)
			{
				for (int k = lines.Length - 1; k >= 0; k--)
				{
					if (lines[k][i] == 'O')
					{
						for (int l = k+1; l < lines.Length; l++)
						{
							if (lines[l][i] == '#' || lines[l][i] == 'O')
								break;
							else
							{
								StringBuilder sb = new StringBuilder(lines[l]);
								sb[i] = 'O';
								lines[l] = sb.ToString();
								sb = new StringBuilder(lines[l - 1]);
								sb[i] = '.';
								lines[l - 1] = sb.ToString();
							}
						}
					}
				}
			}
		}

		public static void shiftWest(string[] lines)
		{
			for(int i = 0;  i < lines.Length; i++)
			{
				for(int k = 1; k < lines[i].Length;k++)
				{
					if (lines[i][k] == 'O')
					{
						for (int l = k-1; l >= 0; l--)
						{
							if (lines[i][l] == '#' || lines[i][l] == 'O')
								break;
							else
							{
								StringBuilder sb = new StringBuilder(lines[i]);
								sb[l] = 'O';
								lines[i] = sb.ToString();
								sb = new StringBuilder(lines[i]);
								sb[l + 1] = '.';
								lines[i] = sb.ToString();
							}
						}
					}
				}
			}
		}

		public static void shiftEast(string[] lines)
		{
			for (int i = 0; i < lines.Length; i++)
			{
				for (int k = lines[i].Length - 1; k >= 0; k--)
				{
					if (lines[i][k] == 'O')
					{
						for (int l = k + 1; l < lines[i].Length; l++)
						{
							if (lines[i][l] == '#' || lines[i][l] == 'O')
								break;
							else
							{
								StringBuilder sb = new StringBuilder(lines[i]);
								sb[l] = 'O';
								lines[i] = sb.ToString();
								sb = new StringBuilder(lines[i]);
								sb[l - 1] = '.';
								lines[i] = sb.ToString();
							}
						}
					}
				}
			}
		}
	}
}
