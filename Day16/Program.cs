using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input16t.txt");
			Console.WriteLine(processField(lines, 'W', -1, 0));
			Console.ReadLine();
			//pohendlej cikle
		}

		public static int processField(string[] lines, char dir, int x, int y)
		{
			switch(dir)
			{
				case 'E':
					x--;
					break;
				case 'W':
					x++;
					break;
				case 'S':
					y--;
					break;
				case 'N':
					y++;
					break;
			}
			if (lines.Length == y || lines.First().Length == x || x < 0 ||y < 0) {
				return 1;
			}
			char c = lines[y][x];
			if (c == '.')
			{
				System.Text.StringBuilder strBuilder = new System.Text.StringBuilder(lines[y]);
				strBuilder[x] = '#';
				lines[y] = strBuilder.ToString();
				File.WriteAllLines("C:\\Users\\PC\\Documents\\AOC\\input16OUT.txt", lines);
			}
			if (c == '/')
			{
				if(dir=='N')
					return processField(lines, 'E', x, y) + 1;
				if (dir == 'E')
					return processField(lines, 'N', x, y) + 1;
				if (dir == 'S')
					return processField(lines, 'W', x, y) + 1;
				if (dir == 'W')
					return processField(lines, 'S', x, y) + 1;
			}
			else if(c == '\\')
			{
				if (dir == 'N')
					return processField(lines, 'W', x, y) + 1;
				if (dir == 'E')
					return processField(lines, 'S', x, y) + 1;
				if (dir == 'S')
					return processField(lines, 'E', x, y) + 1;
				if (dir == 'W')
					return processField(lines, 'N', x, y) + 1;
			}
			else if(c == '|')
			{
				if (dir == 'N')
					return processField(lines, 'N', x, y) + 1;
				if (dir == 'E')
				{
					int a =  processField(lines, 'N', x, y) + 1;
					return processField(lines, 'S', x, y) + a;
				}
				if (dir == 'S')
					return processField(lines, 'S', x, y) + 1;
				if (dir == 'W')
				{
					int a = processField(lines, 'N', x, y) + 1;
					return processField(lines, 'S', x, y) + a;
				}
			}
			else if (c == '-')
			{
				if (dir == 'E')
					return processField(lines, 'E', x, y) + 1;
				if (dir == 'N')
				{
					int a = processField(lines, 'E', x, y) + 1;
					return processField(lines, 'W', x, y) + a;
				}
				if (dir == 'W')
					return processField(lines, 'W', x, y) + 1;
				if (dir == 'S')
				{
					int a = processField(lines, 'E', x, y) + 1;
					return processField(lines, 'W', x, y) + a;
				}
			}
			else
			{
				return processField(lines, dir, x, y) + 1;
			}
			return 1;
		}
	}
}
