using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Demo.TestPatterns.Tests
{
    public class Tests
    {
        [Test]
        public async Task given_payrun_locked_when_performing_an_action_successfully_then_payrun_unlocked()
        {
            var output = Console.Out;
            var payRunId = 1200;

            await using (var myLock = new PayrollLock(output, payRunId))
            {
                await output.WriteLineAsync($"Performing action for pay run id {payRunId}.");
            }
        }

        [Test]
        public async Task given_payrun_locked_when_performing_an_action_with_exception_then_payrun_unlocked()
        {
            var output = Console.Out;
            var payRunId = 1200;

            await using (var myLock = new PayrollLock(output, payRunId))
            {
                await output.WriteLineAsync($"Performing action for pay run id {payRunId}.");
                Assert.Fail("Something went wrong when performing action for pay run id");
            }
        }
    }
}