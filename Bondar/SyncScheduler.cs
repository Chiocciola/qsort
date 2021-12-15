using System;

namespace Bondar
{
    public class SyncScheduler<T>: IScheduler<T>
    {
        private Action<T>? m_handler;

        public void SetHandler(Action<T> handler)
        {
            m_handler = handler;
        }

        public void Enque(T t)
        {
            m_handler?.Invoke(t);
        }

        public void Wait()
        {
        }
    }
}