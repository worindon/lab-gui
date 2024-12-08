﻿namespace lab_gui.model
{
    public class SystemClock
    {
        long clock;

        public long Clock
        {
            get => clock;
            private set => clock = value;
        }

        public void WorkingCycle() => Clock++;

        public void Clear() => Clock = 0;
    }
}