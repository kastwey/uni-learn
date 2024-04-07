using UniLearn.Abstractions;

using System;

namespace UniLearn.WordEngine
{
    public class Clock : IClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}