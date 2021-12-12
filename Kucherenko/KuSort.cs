namespace SortingAlgorithms
{
    public static class KuSort
    {
        public static void NaiveSort(int[] array) => Sort(array, 0, array.Length - 1);

        private static void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = Partition(array, startIndex, endIndex);
                Sort(array, startIndex, pivotIndex - 1);
                Sort(array, pivotIndex + 1, endIndex);
            }
        }

        private static int Partition(int[] array, int startIndex, int endIndex)
        {
            int pivot = array[endIndex];
            int pivotIndex = startIndex;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (array[i] < pivot)
                {
                    if (i > pivotIndex)
                    {
                        (array[i], array[pivotIndex]) = (array[pivotIndex], array[i]);
                    }

                    pivotIndex++;
                }
            }

            for (int i = endIndex; i > pivotIndex; i--)
            {
                array[i] = array[i - 1];
            }

            array[pivotIndex] = pivot;
            return pivotIndex;
        }
    }
}