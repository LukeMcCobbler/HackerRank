using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    class Range
    {
        public int start;
        public int end;
        public long sum;
        public Range(int start,int end, long sum)
        {
            this.start = start;
            this.end = end;
            this.sum = sum;
        }
    }
    // Complete the arrayManipulation function below.
    static long arrayManipulation(int n, int[][] queries)
    {
        List<Range> ranges = new List<Range>();
        foreach(var query in queries)
        {
            addRange(new Range(query[0], query[1], query[2]), ranges);
        }
        return ranges.Select(rng => rng.sum).Max();        
    }

    private static void addRange(Range range, List<Range> ranges)
    {
        for(int i=0;i<ranges.Count;i++)
        {
            var intersectionCandidate = ranges[i];
            if(intersectionCandidate.start>range.end)
            {
                ranges.Insert(i, range);
                break;
            }
            if(intersectionCandidate.end<range.start)
            {
                //No intersection;
            }
            else
            {
                ranges.RemoveAt(i);
                insertIntersection(ranges, i, range, intersectionCandidate);
            }
        }
    }

    private static void insertIntersection(List<Range> ranges, int i, Range range, Range intersectionCandidate)
    {
        
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());
        var rawNm= "5 3";//Console.ReadLine()
        string[] nm = rawNm.Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        var rawQueries = new string[] { "1 2 100", "2 5 100", "3 4 100" };
        for (int i = 0; i < m; i++)
        {
            var query = rawQueries[i];//Console.ReadLine();
            queries[i] = Array.ConvertAll(query.Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
