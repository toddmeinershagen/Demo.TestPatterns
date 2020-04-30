using System;
using System.IO;
using System.Threading.Tasks;

namespace Demo.TestPatterns.Tests
{
    public class PayrollLock : IAsyncDisposable
    {
        private readonly TextWriter _output;
        private readonly int _payRunId;

        public PayrollLock(TextWriter output, int payRunId)
        {
            _output = output;
            _payRunId = payRunId;

            _output.WriteLineAsync($"Locked payroll for pay run id {_payRunId}.").Wait();
        }

        public async ValueTask DisposeAsync()
        {
            await _output.WriteLineAsync($"Unlocked payroll for pay run id {_payRunId}");
        }
    }
}