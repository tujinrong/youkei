using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangFireTaskTest
{
    public class RunOnSpecificServerAttribute : NUnitAttribute, IWrapSetUpTearDown
    {
        private readonly string _targetServer;

        public RunOnSpecificServerAttribute(string targetServer)
        {
            _targetServer = targetServer;
        }

        public TestCommand Wrap(TestCommand command)
        {
            return new RunOnSpecificServerCommand(command, _targetServer);
        }

        private class RunOnSpecificServerCommand : DelegatingTestCommand
        {
            private readonly string _targetServer;

            public RunOnSpecificServerCommand(TestCommand innerCommand, string targetServer)
                : base(innerCommand)
            {
                _targetServer = targetServer;
            }

            public override NUnit.Framework.Internal.TestResult Execute(NUnit.Framework.Internal.TestExecutionContext context)
            {
                var currentServer = Environment.GetEnvironmentVariable("SERVER_NAME");

                if (currentServer != _targetServer)
                {
                    context.CurrentResult.SetResult(ResultState.Skipped,"");

                    return context.CurrentResult;
                }

                return innerCommand.Execute(context);
            }
        }

    }
}
