namespace SortingAlgorithms
{
    public class SyncScheduler<T>: IScheduler<T>
    {
        private Action<T, IScheduler<T>> m_handler;

        public SyncScheduler(Action<T, IScheduler<T>> handler)
        {
            m_handler = handler;
        }

        public void Enque(T t)
        {
            m_handler(t, this);
        }

        public void Wait()
        {
        }

    }
}