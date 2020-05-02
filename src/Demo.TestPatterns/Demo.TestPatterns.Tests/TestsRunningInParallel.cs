using NUnit.Framework;
using System;
using System.Threading.Tasks;

//Uncomment this line if you want to limit the amount of parallelism.
//[assembly:LevelOfParallelism(1)]

namespace Demo.TestPatterns.Tests
{
    [Parallelizable(ParallelScope.Children)]
    [TestFixture]
    public class TestsRunningInParallel
    {
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public async Task this_method_demonstrates_long_running_logic()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        [TestCase()]
        [TestCase()]
        [TestCase()]
        public async Task this_method_demonstrates_long_running_logic_too()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }
}