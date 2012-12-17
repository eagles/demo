using System;
using System.Collections.Generic;

namespace BubbleSort
{
    public class BubbleSortV4
    {
        private List<int> _list;
        private bool _isAsc = true;

        public bool IsAsc
        {
            get { return _isAsc; }
            set { _isAsc = value; }
        }

        public BubbleSortV4()
        {
            _list = new List<int>();
        }

        public void Init(List<int> list, int count)
        {
            Random a = new Random();
            for (int i = 0; i < count; i++)
                list.Add(a.Next(100));
        }

        /// <summary>
        /// Sort a specific range (from low to high) of an int array 
        /// </summary>
        /// <param name="list">raw int array</param>
        /// <param name="low">Start pos</param>
        /// <param name="high">End pos</param>
        /// <returns>Formatted int array</returns>
        public List<int> Sort(List<int> list, int low, int high)
        {
            int highPos = list.Count < high + 1 ? list.Count : high + 1;
            int lowPos = low < 0 ? 0 : low;

            for (int i = lowPos; i < highPos; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (IsAsc)
                    {
                        // Sort Ascending, if list[i] < list[j] will sort descending
                        if (list[i] > list[j])
                        {
                            int tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }
                    }
                    else
                    {
                        // Sort Descending, if list[i] < list[j] will sort descending
                        if (list[i] < list[j])
                        {
                            int tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }
                    }
                }
            }
            return list;
        }

        public List<int> Sort(List<int> list)
        {
            return Sort(list, 0, list.Count - 1);
        }
    }
}
