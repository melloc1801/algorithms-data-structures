namespace Algorithms;

public class Sorter<T>: ISorter<T>
{
    public void Swap(T[] arr, int positionA, int positionB)
    {
        (arr[positionA], arr[positionB]) = (arr[positionB], arr[positionA]);
    }

    public void BubbleSort(T[] arr)
    {
        if (arr.Length < 2)
        {
            return;
        }

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                var current = arr[j - 1];
                var next = arr[j];

                if (Comparer<T>.Default.Compare(current, next) > 0)
                {
                    Swap(arr, j - 1, j);
                } 
            }
        }
    }
}