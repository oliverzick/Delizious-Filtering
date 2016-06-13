#region Copyright and license
// <copyright file="EqualityTest.cs" company="Oliver Zick">
//     Copyright (c) 2016 Oliver Zick. All rights reserved.
// </copyright>
// <author>Oliver Zick</author>
// <license>
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.
// </license>
#endregion

namespace Delizious.Filtering
{
    using System.Linq;

    internal sealed class EqualityTest
    {
        private readonly IStrategy strategy;

        private EqualityTest(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public static EqualityTest Succeed(bool actual)
        {
            return new EqualityTest(new Strategy(true, actual));
        }

        public static EqualityTest Fail(bool actual)
        {
            return new EqualityTest(new Strategy(false, actual));
        }

        public static EqualityTest Multiple(params EqualityTest[] testCases)
        {
            return new EqualityTest(new MultipleStrategy(testCases.Select(test => test.strategy).ToArray()));
        }

        public bool Succeeds()
        {
            return this.strategy.Succeeds();
        }

        private interface IStrategy
        {
            bool Succeeds();
        }

        private sealed class Strategy : IStrategy
        {
            private readonly bool expected;

            private readonly bool actual;

            public Strategy(bool expected, bool actual)
            {
                this.expected = expected;
                this.actual = actual;
            }

            public bool Succeeds()
            {
                return this.expected == this.actual;
            }
        }

        private sealed class MultipleStrategy : IStrategy
        {
            private readonly IStrategy[] strategies;

            public MultipleStrategy(IStrategy[] strategies)
            {
                this.strategies = strategies;
            }

            public bool Succeeds()
            {
                return this.strategies.All(strategy => strategy.Succeeds());
            }
        }
    }
}
