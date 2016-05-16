#region Copyright and license
// // <copyright file="AnyTests.cs" company="Oliver Zick">
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
    public sealed class AnyTests
    {
        [TestMethod]
        public void Match_Fails_When_No_Matches_Are_Given()
        {
            Assert.IsFalse(Match.Any<GenericParameterHelper>().Matches(null));
        }

        [TestMethod]
        public void Match_Succeeds_When_All_Matches_Succeed()
        {
            Assert.IsTrue(Match.Any(Match.Always<GenericParameterHelper>(),
                                    Match.Always<GenericParameterHelper>(),
                                    Match.Always<GenericParameterHelper>()).Matches(null));
        }

        [TestMethod]
        public void Match_Succeeds_When_At_Least_One_Match_Succeeds()
        {
            Assert.IsTrue(Match.Any(Match.Never<GenericParameterHelper>(),
                                    Match.Always<GenericParameterHelper>(),
                                    Match.Never<GenericParameterHelper>()).Matches(null));
        }

        [TestMethod]
        public void Match_Fails_When_All_Matches_Fail()
        {
            Assert.IsFalse(Match.Any(Match.Never<GenericParameterHelper>(),
                                     Match.Never<GenericParameterHelper>(),
                                     Match.Never<GenericParameterHelper>()).Matches(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Exception_On_Creation_When_Matches_Are_Null()
        {
            Match.Any<GenericParameterHelper>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throws_Exception_On_Creation_When_Matches_Contain_At_Least_One_Null_Reference()
        {
            Match.Any(Match.Always<GenericParameterHelper>(), null);
        }
    }
}
