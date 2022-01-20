using System;
using System.Collections.Generic;

namespace ObserveWeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class WeatherInfo
    {
        internal WeatherInfo(double temperature)
        {
            Temperature = temperature;
        }

        public double Temperature { get; }
    }
    public class WeatherForecast : IObservable<WeatherInfo>
    {
        private readonly List<IObserver<WeatherInfo>> m_Observers;
        private readonly List<WeatherInfo> m_WeatherInfoList;

        public WeatherForecast()
        {
            m_Observers = new List<IObserver<WeatherInfo>>();
            m_WeatherInfoList = new List<WeatherInfo>();
        }

        public IDisposable Subscribe(IObserver<WeatherInfo> observer)
        {
            if (!m_Observers.Contains(observer))
            {
                m_Observers.Add(observer);

                foreach (var item in m_WeatherInfoList)
                {
                    observer.OnNext(item);
                }
            }

            return new WeatherForecastUnsubscriber(m_Observers, observer);
        }

        public void RegisterWeatherInfo(WeatherInfo weatherInfo)
        {
            m_WeatherInfoList.Add(weatherInfo);

            foreach (var observer in m_Observers)
            {
                observer.OnNext(weatherInfo);
            }
        }

        public void ClearWeatherInfo()
        {
            m_WeatherInfoList.Clear();
        }
    }
    public class Unsubscriber<T> : IDisposable
    {
        private readonly List<IObserver<T>> m_Observers;
        private readonly IObserver<T> m_Observer;
        private bool m_IsDisposed;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            m_Observers = observers;
            m_Observer = observer;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_IsDisposed) return;

            if (disposing && m_Observers.Contains(m_Observer))
            {
                m_Observers.Remove(m_Observer);
            }

            m_IsDisposed = true;
        }

        ~Unsubscriber()
        {
            Dispose(false);
        }
    }
    public class WeatherForecastUnsubscriber : Unsubscriber<WeatherInfo>
    {
        public WeatherForecastUnsubscriber(
            List<IObserver<WeatherInfo>> observers,
            IObserver<WeatherInfo> observer) : base(observers, observer)
        {
        }
    }
}
