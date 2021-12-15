using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Bondar
{
    public class TaskBasedScheduler<T>: IScheduler<T>
    {
        private readonly ConcurrentQueue<T> m_queue = new ConcurrentQueue<T>();
        private readonly CountdownEvent m_doneEvent = new CountdownEvent(1);

        private Action<T>? m_action;

        public void SetHandler(Action<T> handler)
        {
            m_action = handler;
        }

        public void Enque(T param)
        {
            m_queue.Enqueue(param);

            if (m_doneEvent.CurrentCount <= 8)
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
                m_action?.Invoke(t);
            }

            m_doneEvent.Signal();
        }
    }
}