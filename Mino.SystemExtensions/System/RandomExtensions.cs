namespace System
{
    internal static class RandomExtensions
    {
        public static float NextSingle(this Random random, float minValue, float maxValue)
        {
            return random.NextSingle() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Return  random double within a specific range
        /// </summary>
        /// <remarks>less than maxValue</remarks>
        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Sampling from Gaussian distribution
        /// </summary>
        /// <param name="random"></param>
        /// <param name="mean">mean</param>
        /// <param name="stddev">standard deviation</param>
        /// <remarks>https://gist.github.com/tansey/1444070</remarks>
        public static double SampleGaussian(this Random random, double mean, double stddev)
        {
            // The method requires sampling from a uniform random of (0,1]
            // but Random.NextDouble() returns a sample of [0,1).
            double x1 = 1.0 - random.NextDouble();
            double x2 = 1.0 - random.NextDouble();

            double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
            return y1 * stddev + mean;
        }
    }
}
