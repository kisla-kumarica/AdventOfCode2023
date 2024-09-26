using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
	internal class Program
	{
		class Node
		{
			public Node left; public Node right;
			public string loc = "";
			public Node(string loc)
			{ this.loc = loc; }
		}
		static string direction = "";
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("C:\\Users\\PC\\Documents\\AOC\\input8.txt");
			List<Node> nodes = new List<Node>();
			direction = lines[0];
			foreach (string line in lines.Skip(2))
			{
				string loc = line.Split('=').First().Trim();
				nodes.Add(new Node(loc));
			}
			foreach (string line in lines.Skip(2))
			{
				string loc = line.Split('=').First().Trim();
				string left = line.Substring(7).Split(',').First().Trim();
				string right = line.Substring(7).Split(',')[1].Substring(1, 3);
				nodes[nodes.FindIndex(i => i.loc == loc)].right = nodes.Where(i => i.loc == right).Single();
				nodes[nodes.FindIndex(i => i.loc == loc)].left = nodes.Where(i => i.loc == left).Single();
			}
			List<Node> curNodes = nodes.Where(i => i.loc.EndsWith("A")).ToList();
			List<Node> orig = new List<Node>(curNodes);
			string dirs = direction;
			long jumps = 0;
			List<List<string>> visited = new List<List<string>>();
			foreach(Node n in curNodes)
				visited.Add(new List<string>());
			long[] loops = new long[curNodes.Count];
			long[] Zs = new long[curNodes.Count];
			while (true)
			{
				if (curNodes.All(i => i.loc.EndsWith("Z")))
					break;
				if (dirs == "")
					dirs = direction;
				char move = dirs.First();
				dirs = dirs.Substring(1);
				for (int i = 0; i < curNodes.Count; i++)
				{
					Node curNode = curNodes[i];
					if (visited[i].Where(k => k+ dirs == curNode.loc+ dirs).Count() == 0)
						visited[i].Add(curNode.loc+dirs);
					else if (jumps > 0 && loops[i] == 0)
					{
						Console.WriteLine("loop detected! i: " + i + "\t jumps: " + jumps + " prev:" + visited[i].FindIndex(k => k+ dirs == curNode.loc+ dirs));
						loops[i] = jumps;
					}
					if (curNode.loc.EndsWith("Z"))
					{
						Console.WriteLine("-----Z detected! i: " + i + "\t jumps: " + jumps);
						Zs[i] = jumps;
					}
					if (move == 'R')
					{
						curNodes[i] = curNode.right;
					}
					else if (move == 'L')
					{
						curNodes[i] = curNode.left;
					}
				}
				jumps++;
				if (Zs.All(i => i > 0))
					break;
			}
			//Console.WriteLine(CountJumps(nodes.Where(i => i.loc == "AAA").Single(), direction));
			Console.WriteLine(jumps);
			Console.ReadLine();
		}
		static int CountJumps(Node curNode, string dirs)
		{
			if (curNode.loc == "ZZZ")
				return 0;
			if (dirs == "")
				dirs = direction;
			if (dirs.First() == 'R')
				return CountJumps(curNode.right, dirs.Substring(1)) + 1;
			if (dirs.First() == 'L')
				return CountJumps(curNode.left, dirs.Substring(1)) + 1;
			return 0;
		}
	}
}
