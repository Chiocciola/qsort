namespace Bondar
{
    public static class InsertionSort
    {
        public static void Sort(int[] a, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
            {
                var toInsert = a[i];
                var j = i;

                while (j > lo && a[j - 1] > toInsert)
                {
                    a[j] = a[--j];
                }

                a[j] = toInsert;
            }
        }
    }
}