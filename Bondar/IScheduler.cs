using System;

namespace Bondar
{
    public interface IScheduler<T>
    {
        void SetHandler(Action<T> handler);

        void Enque(T param);

        void Wait();
    }
}