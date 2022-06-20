using System;

namespace PEN
{
    internal class Program
    {
        static int MAX = 1000004;
        static int[] boss = new int[MAX];
        static int[] used = new int[MAX];
        static int[] numberOfWorkers = new int[MAX];
        static int[] cWorker = new int[MAX];
        static int[] queue = new int[MAX];
        static int[] level = new int[MAX];
        static int[] money = new int[MAX];

        static int start = 0, end = 0;
        static int n = 0;

        static void countWorkers()
        {
            for(int i=1; i<n; ++i)
            {
                level[i] = 0;
            }
            for(int i=1; i<n; ++i)
            {
                ++level[boss[i]];
            }
            for(int i=1; i<n; ++i)
            {
                if (level[i] == 0)
                    queue[end++] = i;
            }
            while (start < end)
            {
                int act = queue[start++];
                int temp = boss[act];
                if (money[act] == 0)
                {
                    if (--level[temp] == 0)
                    {
                        queue[end++] = temp;
                    }
                    numberOfWorkers[temp] += numberOfWorkers[act] + 1;
                }
            }
        }

        static void checkUsed()
        {
            for(int i=1; i<n; ++i)
            {
                if (money[i] != 0)
                {
                    used[money[i]] = i;
                }
                else if (cWorker[boss[i]] == 0)
                {
                    cWorker[boss[i]] = i;
                }
                else
                    cWorker[boss[i]] = -1;
            }
        }



        static void Main(string[] args)
        {
            for(int j=0; j<MAX; j++)
            {
                boss[j] = 0;
                used[j] = 0;
                numberOfWorkers[j] = 0;
                cWorker[j] = 0;
                queue[j] = 0;
                level[j] = 0;
                money[j] = 0;

            }
            n = Convert.ToInt32(Console.ReadLine());

            for (int j=1; j<=n; j++)
            {
                string[] input = Console.ReadLine().Split(' ');
                boss[j] = Convert.ToInt32(input[0]);
                money[j] = Convert.ToInt32(input[1]);
                if (boss[j] == j)
                {
                    money[j] = n;
                }
                if (money[j] != 0)
                {
                    boss[j] = n + 1;
                }
            }
            ++n;
            boss[n] = n;
            money[n] = n;
            countWorkers();
            checkUsed();
            int i = 0;
            int free = 0, possible = 0;
            while (i < n - 1)
            {
                while(i < n-1 && used[i+1] == 0)
                {
                    ++i;
                    ++free;
                    ++possible;
                }
                while(i<n-1 && used[i+1] != 0)
                {
                    ++i;
                    int act = used[i], l = i;
                    free -= numberOfWorkers[act];
                    if(free == 0)
                    {
                        while(possible-- != 0 && cWorker[act] > 0)
                        {
                            while (used[l] != 0)
                            {
                                --l;
                            }
                            act = cWorker[act];
                            money[act] = l;
                            used[l] = act;
                        }
                        possible = 0;
                    }
                    if(numberOfWorkers[act] != 0)
                    {
                        possible = 0;
                    }
                }
            }
            for(int j=1; j<n; ++j)
            {
                Console.WriteLine(money[j]);
            }
        }
    }
}
