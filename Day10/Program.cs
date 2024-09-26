using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input10.txt");
			string[] justPath = new string[lines.Length];
			for(int i = 0; i < justPath.Length; i++)
			{
				justPath[i] = new string('.', lines[i].Length);
			}
			char cur = ' ';
			int y = Array.FindIndex(lines, i => i.Contains('S'));
			int x = lines[y].IndexOf('S');
			int jumps = 0;
			char dir = ' ';
			while(cur != 'S')
			{
				StringBuilder sb = new StringBuilder(justPath[y]);
				sb[x] = cur;
				justPath[y] = sb.ToString();
				if (cur == ' ')
				{
					if (y > 0 && (lines[y - 1][x] == '7' || lines[y - 1][x] == 'F' || lines[y - 1][x] == '|'))
					{
						dir = 'S';
						y--;
					}
					else if (lines[y + 1][x] == 'L' || lines[y + 1][x] == 'J' || lines[y + 1][x] == '|')
					{
						dir = 'N';
						y++;
					}
					else if (lines[y][x + 1] == '7' || lines[y][x + 1] == 'J' || lines[y][x + 1] == '-')
					{
						dir = 'W';
						x++;
					}
					else if (x > 0 && (lines[y][x - 1] == 'F' || lines[y][x - 1] == 'L' || lines[y][x - 1] == '-'))
					{
						dir = 'E';
						x--;
					}
					cur = lines[y][x];
					jumps++;
				}
				else
				{
					switch(cur)
					{
						case '7':
							if (dir == 'S')
							{
								dir = 'E';
								x--;
							}
							if(dir == 'W')
							{
								dir = 'N';
								y++;
							}
							break;
						case 'J':
							if (dir == 'N')
							{
								dir = 'E';
								x--;
							}
							if (dir == 'W')
							{
								dir = 'S';
								y--;
							}
							break;
						case 'L':
							if (dir == 'N')
							{
								dir = 'W';
								x++;
							}
							if (dir == 'E')
							{
								dir = 'S';
								y--;
							}
							break;
						case 'F':
							if (dir == 'S')
							{
								dir = 'W';
								x++;
							}
							if (dir == 'E')
							{
								dir = 'N';
								y++;
							}
							break;
						case '|':
							if (dir == 'S')
							{
								dir = 'S';
								y--;
							}
							if (dir == 'N')
							{
								dir = 'N';
								y++;
							}
							break;
						case '-':
							if (dir == 'E')
							{
								dir = 'E';
								x--;
							}
							if (dir == 'W')
							{
								dir = 'W';
								x++;
							}
							break;
					}
					cur = lines[y][x];
					jumps++;

				}
			}
			bool inside = false;
			int inCount = 0;
			for(int i = 0; i < justPath.Length; i++)
			{
				for(int k = 0; k < justPath[i].Length; k++)
				{
					if (justPath[i][k] == '.' && inside)
						inCount++;
					else if (justPath[i][k] == 'L'|| justPath[i][k] == 'J'|| justPath[i][k] == '|' || justPath[i][k] == ' ')
						inside = !inside;
				}
				inside = false;
			}
			Console.WriteLine(inCount);
			Console.ReadLine();
		}
	}
}
