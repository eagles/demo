namespace BubbleSort
{
    public class BubbleSortV1
    {
        /// <summary>
        /// A simple bubble sort method for int array data.
        /// 问题：包含算法实现，调用，实现糅合在一起
        /// </summary>
        /// <param name="list">unsorted array</param>
        /// <returns>sorted array</returns>
        public int[] Sort(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
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
