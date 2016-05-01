#region Copyright and license
// // <copyright file="LessThanOrEqualToTests.cs" company="Oliver Zick">
// //     Copyright (c) 2016 Oliver Zick. All rights reserved.
// // </copyright>
// // <author>Oliver Zick</author>
// // <license>
// //     Licensed under the Apache License, Version 2.0 (the "License");
// //     you may not use this file except in compliance with the License.
// //     You may obtain a copy of the License at
// // 
// //     http://www.apache.org/licenses/LICENSE-2.0
// // 
// //     Unless required by applicable law or agreed to in writing, software
// //     distributed under the License is distributed on an "AS IS" BASIS,
// //     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //     See the License for the specific language governing permissions and
// //     limitations under the License.
// // </license>
#endregion

namespace Delizious.Filtering
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class LessThanOrEqualToTests
    {
        [TestMethod]
        public void Fail__When_Value_Is_Greater_Than_Reference()
        {
            Assert.IsFalse(Match.LessThanOrEqualTo(0).Matches(1));
        }

        [TestMethod]
        public void Succeed__When_Reference_And_Value_Are_Equal()
        {
            Assert.IsTrue(Match.LessThanOrEqualTo(0).Matches(0));
        }

        [TestMethod]
        public void Succeed__When_Value_Is_Less_Than_Reference()
        {
            Assert.IsTrue(Match.LessThanOrEqualTo(0).Matches(-1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception__When_Reference_Is_Null()
        {
            Match.LessThanOrEqualTo<string>(null);
        }
    }
}
