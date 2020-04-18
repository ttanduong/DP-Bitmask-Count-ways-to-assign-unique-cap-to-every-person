using System;
using System.Collections.Generic;

public class Cap
{		
	int allMask;
	int[,] dp = new int[1025,101];
	List<int>[] capList = new List<int> [101];		
	
	public int countWay(int n)
	{
		for (int i = 0; i < 101; i++)
		{
			capList[i] = new List<int>();
			for (int j = 0; j < 1025; j++)
			{
				dp[j,i] = -1;
			}
		}
		
		for (int i = 0; i < n; i++)
		{
			string line = Console.ReadLine();
			string[] cap = line.Split(' ');
			foreach (var x in cap)
			{
				capList[int.Parse(x)].Add(i);
			}
		}	
		
		allMask = (1 << n) -1;
		
		return countWayUtil(0, 1);
	}
	
	public int countWayUtil(int mask, int i)
	{
		if (mask == allMask) return 1;
		if (i > 100)	return 0;
		if (dp[mask,i] != -1)	return dp[mask,i];
		
		int ways = countWayUtil(mask, i + 1);
		
		for (int j = 0; j < capList[i].Count; j++)
		{
			if ((mask & (1 << capList[i][j])) != 0) continue;
			else
			{
				ways += countWayUtil(mask | (1 << capList[i][j]), i + 1);
			}				
		}
		
		dp[mask,i] = ways;
		
		return dp[mask,i];
	}
}

public class Program
{
	public static void Main()
	{
		Cap cap = new Cap();
		
		string line;
		
		while ((line = Console.ReadLine()) != null)
		{
			Console.WriteLine(cap.countWay(int.Parse(line)));
		}
	}
}
