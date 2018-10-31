using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playerNames = { "Sid", "Bill", "Rivers Cuomo", "Billy Bob", "Charlize" };
            int[] playerGoals = { 9, 7, 3, 1, 0 };
            int[] playerAssists = { 9, 6, 10, 4, 5 };

            DisplayPlayers(playerNames, playerGoals, playerAssists);

            SortByAssists(playerNames, playerGoals, playerAssists);
            DisplayPlayers(playerNames, playerGoals, playerAssists);

            SortByGoals(playerNames, playerGoals, playerAssists);
            DisplayPlayers(playerNames, playerGoals, playerAssists);

            SortByNames(playerNames, playerGoals, playerAssists);
            DisplayPlayers(playerNames, playerGoals, playerAssists);
        }

        static void SortByAssists(string[] names, int[] goals, int[] assists)
        {
            int len = assists.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (assists[j] < assists[minIdx])
                        minIdx = j;
                }

                Swap(names, i, minIdx);
                Swap(goals, i, minIdx);
                Swap(assists, i, minIdx);
            }

        }

        static void SortByGoals(string[] names, int[] goals, int[] assists)
        {
            int len = goals.Length;
            for (int i = 0; i < len - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (goals[j] > goals[maxIdx])
                        maxIdx = j;
                }

                if (maxIdx != i)
                {
                    Swap(names, i, maxIdx);
                    Swap(goals, i, maxIdx);
                    Swap(assists, i, maxIdx);
                }
            }
        }

        static void SortByNames(string[] names, int[] goals, int[] assists)
        {
            int len = names.Length;
            for (int sortIdx = 0; sortIdx < len - 1; sortIdx++)
            {
                int minIdx = sortIdx;
                for (int curIdx = sortIdx + 1; curIdx < len; curIdx++)
                {
                    int result = string.Compare(names[curIdx], names[minIdx], ignoreCase: true);
                    if (result < 0)
                        minIdx = curIdx;
                }

                if (minIdx != sortIdx)
                {
                    Swap(names, sortIdx, minIdx);
                    Swap(goals, sortIdx, minIdx);
                    Swap(assists, sortIdx, minIdx);
               }
            }
        }

        static void Swap(int[] arr, int a, int b)
        {
            var tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        static void Swap(string[] arr, int a, int b)
        {
            var tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        static void DisplayPlayers(string[] names, int[] goals, int[] assists)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{names[i]}\n  Goals: {goals[i]}\t Assists: {assists[i]}");
            }
            Console.WriteLine();
        }
    }
}
