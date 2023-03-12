namespace TaxCalculator.Domain
{
    public class FeeConfig
    {
        public TimeValue Start { get; private set; }

        public TimeValue End { get; private set; }

        public int Fee { get; private set; }

        public FeeConfig(TimeValue start, TimeValue end, int fee)
        {
            Start = start;
            End = end;
            Fee = fee;
        }
    }

    public class TimeValue
    {
        public int Hour { get; private set; }

        public int Minute { get; private set; }

        public TimeValue(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
    }
}