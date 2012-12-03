using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public class BubbleSortV2
    {
        public void Init(List<int> list, int count)
        {
            Random a = new Random();
            for (int i = 0; i < count; i++)
                list.Add(a.Next(100));
        }

        public List<int> Sort(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    // Sort Ascending, if list[i] < list[j] will sort descending
                    if (list[i] > list[j])
                    {
                        int tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                }
            }
            return list;
        }
    }
}
