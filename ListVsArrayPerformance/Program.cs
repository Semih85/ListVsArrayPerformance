using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

static class Program
{
    static void Main()
    {
        List<int> list = new List<int>(6000000);
        int[] arr = new int[6000000];

        Random rand = new Random(12345);
        for (int i = 0; i < 6000000; i++)
        {
            var a = rand.Next(5000);
            arr[i] = a;
            list.Add(a);
        }
        //int[] arr = list.ToArray();

        int chk = 0;
        int len = arr.Length;
        int rptLenght = 100;
        Stopwatch watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < rptLenght; rpt++)
        {
            //int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                chk += list[i];
            }
        }
        watch.Stop();
        Console.WriteLine("List/for: {0}ms ({1})", watch.ElapsedMilliseconds, chk);

        chk = 0;
        watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < rptLenght; rpt++)
        {
            for (int i = 0; i < len; i++)
            {
                chk += arr[i];
            }
        }
        watch.Stop();
        Console.WriteLine("Array/for: {0}ms ({1})", watch.ElapsedMilliseconds, chk);

        chk = 0;
        watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < rptLenght; rpt++)
        {
            foreach (int i in list)
            {
                chk += i;
            }
        }
        watch.Stop();
        Console.WriteLine("List/foreach: {0}ms ({1})", watch.ElapsedMilliseconds, chk);

        chk = 0;
        watch = Stopwatch.StartNew();
        for (int rpt = 0; rpt < rptLenght; rpt++)
        {
            foreach (int i in arr)
            {
                chk += i;
            }
        }
        watch.Stop();
        Console.WriteLine("Array/foreach: {0}ms ({1})", watch.ElapsedMilliseconds, chk);

        Console.ReadLine();
    }
}