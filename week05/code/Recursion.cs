using System;
using System.Collections.Generic;

public static class Recursion
{

    // Problem 1: Sum of Squares

    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations Choose

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    // Problem 3: Climbing Stairs (Memoization)

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    // Problem 4: Wildcard Binary Patterns

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }
        // Replace the wildcard '*' with '0' and '1' and recurse
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);

        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    // Problem 5: Maze Solver

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        var moves = new (int dx, int dy)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        foreach (var move in moves)
        {
            int newX = x + move.dx;
            int newY = y + move.dy;

            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }
        
        currPath.RemoveAt(currPath.Count - 1);
    }
}
