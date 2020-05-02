using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Demo.TestPatterns.Tests
{
    [Parallelizable(ParallelScope.Children)]
    public class PayrollLockTests
    {
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public async Task given_payrun_locked_when_performing_an_action_successfully_then_payrun_unlocked()
        {
            var payRunId = 1201;

            await Task.Delay(TimeSpan.FromSeconds(2));

            await using (var myLock = new PayrollLock(Console.Out, payRunId))
            {
                await Console.Out.WriteLineAsync($"Performing action for pay run id {payRunId}.");
            }
        }

        [TestCase()]
        [TestCase()]
        [TestCase()]
        public async Task given_payrun_locked_when_performing_an_action_with_exception_then_payrun_unlocked()
        {
            var payRunId = 1200;

            await Task.Delay(TimeSpan.FromSeconds(2));

            await using (var myLock = new PayrollLock(Console.Out, payRunId))
            {
                await Console.Out.WriteLineAsync($"Performing action for pay run id {payRunId}.");
                Assert.Fail($"Something went wrong when performing action for pay run id {payRunId}.");
            }
        }
    }
}