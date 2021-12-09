using System;
using System.Collections.Generic;
using System.Threading;

namespace SortingAlgorithms
{
    public class ThreadScheduler<T>: IScheduler<T>
    {
        private int ActiveThreadCount = 0;

        private CountdownEvent m_noMoreThreadsEvent = new CountdownEvent(0);

        private readonly Queue<T> m_queue = new Queue<T>();

        private readonly Action<T, IScheduler<T>> m_action;

        public ThreadScheduler(Action<T, IScheduler<T>> action)
        {
            m_action = action;
        }

        public void Enque(T param)
        {
            lock (m_queue)
            {
                m_queue.Enqueue(param);

                // Wakeup one thread
                Monitor.Pulse(m_queue);
            }

            if (m_noMoreThreadsEvent.IsSet)
            {
                InitThreads();
            }
        }

        public void Wait()
        {
            m_noMoreThreadsEvent.Wait();
        }

        private void InitThreads()
        {
            m_noMoreThreadsEvent = new CountdownEvent(8);

            for (int i = 0; i < 8; i++)
            {
                new Thread(ThreadBody).Start();

                //Task.Run(ThreadBody);
            }
        }

        private void ThreadBody()
        {
            Interlocked.Increment(ref ActiveThreadCount);

            while (true)
            {
                T t;

                lock(m_queue)
                {
                    if (m_queue.Count == 0)
                    {
                        Interlocked.Decrement(ref ActiveThreadCount);
                        //Console.WriteLine($"Threads: {ActiveThreadCount}");

                        // Queue is empty, other threads are sleeping - work is done
                        if (Interlocked.Equals(ActiveThreadCount, 0))
                        {
                            // Wakeup other threads
                            Monitor.PulseAll(m_queue);
                            break;
                        }

                        // Sleep
                        Monitor.Wait(m_queue);

                        // If thread has been wokeup and queue is empty - need to terminate
                        if (m_queue.Count == 0)
                        {
                            break;
                        }

                        Interlocked.Increment(ref ActiveThreadCount);
                        //Console.WriteLine($"Threads: {ActiveThreadCount}");
                    }

                    t = m_queue.Dequeue();
                }

                m_action(t, this);
            }

            m_noMoreThreadsEvent.Signal();
        }
    }
}