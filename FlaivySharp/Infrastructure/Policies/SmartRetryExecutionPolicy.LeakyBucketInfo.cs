namespace FlaivySharp.Infrastructure.Policies
{
    public partial class SmartRetryExecutionPolicy
    {
        private class LeakyBucketState
        {
            public int Capacity { get; }
            public int CurrentFillLevel { get; }

            public LeakyBucketState(int capacity, int currentFillLevel)
            {
                Capacity = capacity;
                CurrentFillLevel = currentFillLevel;
            }
        }
    }
}