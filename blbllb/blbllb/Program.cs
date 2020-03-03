using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sortering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hur många tal vill du ordna?");
            Random slump = new Random();
            int a = int.Parse(Console.ReadLine());
            int[] tallista = new int[a];
            for (int i = 0; i < a; i++)
            {
                tallista[i] = slump.Next(2000000);
            }
            Stopwatch s = new Stopwatch();
            int[] torg = new int[a];
            for (int i = 0; i < a; i++)
            {
                torg[i] = tallista[i];
            }

            Console.WriteLine("Vill du köra bubble?");
            string tid;
            TimeSpan ts;
            if (Console.ReadLine() == "j")
            {
                s.Start();
                Bubble(tallista);
                s.Stop();
                ts = s.Elapsed;
                tid = Convert.ToString(ts.TotalMilliseconds);
                Console.WriteLine("Bubble: " + tid + "ms");
                s.Reset();
            }
            for (int i = 0; i < a; i++)
            {
                tallista[i] = torg[i];
            }
            Console.WriteLine("Vill du köra Selection?");
            if (Console.ReadLine() == "j")
            {
                s.Start();
                Selection(tallista);
                s.Stop();
                ts = s.Elapsed;
                tid = Convert.ToString(ts.TotalMilliseconds);
                Console.WriteLine("Selection: " + tid + "ms");
                s.Reset();
            }
            for (int i = 0; i < a; i++)
            {
                tallista[i] = torg[i];
            }
            Console.WriteLine("Vill du köra Merge?");
            if (Console.ReadLine() == "j")
            {
                List<int> sort = new List<int>();
                foreach (int e in tallista)
                {
                    sort.Add(e);
                }
                s.Start();
                Merge(ref sort);
                s.Stop();
                ts = s.Elapsed;
                tid = Convert.ToString(ts.TotalMilliseconds);
                Console.WriteLine("Merge: " + tid + "ms");
                s.Reset();

            }
            for (int i = 0; i < a; i++)
            {
                tallista[i] = torg[i];
            }
            Console.WriteLine("Vill du köra Quick?");
            if (Console.ReadLine() == "j")
            {
                s.Start();
                Quick(tallista);
                s.Stop();
                ts = s.Elapsed;
                tid = Convert.ToString(ts.TotalMilliseconds);
                Console.WriteLine("Quick: " + tid + "ms");
            }
        }
        static void Bubble(int[] t)
        {
            int n;
            while (true)
            {

                n = 0;
                for (int i = 1; i < t.Length; i++)
                {
                    if (t[i - 1] > t[i])
                    {
                        int v = t[i - 1];
                        t[i - 1] = t[i];
                        t[i] = v;
                        n++;
                    }
                }
                if (n == 0)
                {
                    break;
                }
            }
            return;
        }
        static void Selection(int[] t)
        {
            int[] tsort = new int[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                int s = 2000000;
                int n = 0;
                for (int e = 0; e < t.Length; e++)
                {
                    if (t[e] < s)
                    {
                        s = t[e];
                        n = e;
                    }

                }
                t[n] = 2000000;
                tsort[i] = s;
            }
            return;
        }
        static void Merge(ref List<int> l)
        {
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            for (int i = 0; i < l.Count; i++)
            {
                if (i < l.Count / 2)
                {
                    l1.Add(l[i]);
                }
                else
                {
                    l2.Add(l[i]);
                }
            }
            if (l1.Count == 1 && l2.Count != 1)
            {
                Merge(ref l2);
            }
            else if (l2.Count == 1 && l1.Count != 1)
            {
                Merge(ref l1);
            }
            else if (l2.Count != 1 && l1.Count != 1)
            {
                Merge(ref l1);
                Merge(ref l2);
            }
            int t = l1.Count + l2.Count;
            int p1 = 0;
            int p2 = 0;
            l.Clear();
            for (int s = 0; s < t; s++)
            {
                if (l1[p1] < l2[p2])
                {
                    l.Add(l1[p1]);
                    p1++;
                    if (p1 >= l1.Count)
                    {
                        l1.Add(2000000);
                    }
                }
                else
                {
                    l.Add(l2[p2]);
                    p2++;
                    if (p2 >= l2.Count)
                    {
                        l2.Add(2000000);
                    }
                }

            }

        }
        static void Quick(int[] t)
        {
            int p = t.Length - 1;
            int c = t[p];

            for (int i = 0; i < p; i++)
            {
                if (t[i] > c)
                {
                    int v = t[i];
                    t[i] = t[p - 1];
                    t[p - 1] = t[p];
                    t[p] = v;
                    p--;
                    i--;
                }


            }

            if (t.Length > 3)
            {
                int[] t1 = new int[p];
                int[] t2 = new int[t.Length - p - 1];
                for (int i = 0; i < p; i++)
                {
                    t1[i] = t[i];
                }
                for (int i = p + 1; i < t.Length; i++)
                {
                    t2[i - p - 1] = t[i];
                }
                if (t1.Length > 1)
                {
                    Quick(t1);
                }
                if (t2.Length > 1)
                {
                    Quick(t2);
                }
                for (int i = 0; i < t1.Length; i++)
                {
                    t[i] = t1[i];
                }
                for (int i = p + 1; i < t.Length; i++)
                {
                    t[i] = t2[i - p - 1];
                }
            }
            return;
        }

    }
}



