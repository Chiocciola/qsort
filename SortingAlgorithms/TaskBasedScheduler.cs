using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class TaskBasedScheduler<T>: IScheduler<T>
    {
        private readonly ConcurrentQueue<T> m_queue = new ConcurrentQueue<T>();
        private readonly Action<T, IScheduler<T>> m_action;
        private readonly CountdownEvent m_doneEvent = new CountdownEvent(1);

        public TaskBasedScheduler(Action<T, IScheduler<T>> action)
        {
            m_action = action;
        }

        public void Enque(T param)
        {
            m_queue.Enqueue(param);

            if (m_doneEvent.CurrentCount <= 4)
            {
                m_doneEvent.AddCount();

                Task.Run(ThreadBody);
            }
        }

        public void Wait()
        {
            lock(m_doneEvent)
            {
                if (m_doneEvent.IsSet)
                {
                    return;
                }

                m_doneEvent.Signal();
                m_doneEvent.Wait();
            }
        }

        private void ThreadBody()
        {
            while (m_queue.TryDequeue(out var t))
            {
                m_action(t, this);
            }

            m_doneEvent.Signal();
        }
    }
}