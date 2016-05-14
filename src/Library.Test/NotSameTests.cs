#region Copyright and license
// // <copyright file="NotSameTests.cs" company="Oliver Zick">
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
    public sealed class NotSameTests
    {
        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_Is_Null_But_Reference_Is_An_Instance()
        {
            Assert.IsTrue(Match.NotSame(new GenericParameterHelper()).Matches(null));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Different_Instances()
        {
            Assert.IsTrue(Match.NotSame(new GenericParameterHelper()).Matches(new GenericParameterHelper()));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_Same_Instance()
        {
            var obj = new GenericParameterHelper();

            Assert.IsFalse(Match.NotSame(obj).Matches(obj));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Match_Throws_Exception_When_Reference_Is_Null()
        {
            Match.NotSame<GenericParameterHelper>(null);
        }
    }
}
