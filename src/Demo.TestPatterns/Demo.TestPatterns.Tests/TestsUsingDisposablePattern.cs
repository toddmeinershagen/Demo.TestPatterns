using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Demo.TestPatterns.Tests
{
    [TestFixture]
    public class PayrollLockTests
    {
        [Test]
        public void given_payrun_locked_when_performing_an_action_successfully_then_payrun_unlocked()
        {
            var payRunId = 1201;

            using (var myLock = new PayrollLock(Console.Out, payRunId))
            {
                Console.Out.WriteLine($"Performing action for pay run id {payRunId}.");
            }
        }

        [Test]
        public async Task given_payrun_locked_when_performing_an_action_with_exception_then_payrun_unlocked()
        {
            var payRunId = 1200;

            await using (var myLock = new PayrollLock(Console.Out, payRunId))
            {
                await Console.Out.WriteLineAsync($"Performing action for pay run id {payRunId}.");
                Assert.Fail($"Something went wrong when performing action for pay run id {payRunId}.");
            }
        }
    }
}