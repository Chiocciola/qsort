namespace SortingAlgorithms
{
    public interface IScheduler<T>
    {
        void Enque(T param);

        void Wait();
    }
}