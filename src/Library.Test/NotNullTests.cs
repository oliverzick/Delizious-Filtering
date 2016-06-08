#region Copyright and license
// <copyright file="NotNullTests.cs" company="Oliver Zick">
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class NotNullTests
    {
        [TestMethod]
        public void Match_Fails_When_Value_To_Match_Is_Null()
        {
            Assert.IsFalse(NewInstance().Matches(null));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_Is_An_Instance()
        {
            Assert.IsTrue(NewInstance().Matches(new GenericParameterHelper()));
        }

        [TestMethod]
        public void Ensure_Equal_Hash_Code_For_Equal_Instances()
        {
            Assert.AreEqual(NewInstance().GetHashCode(), NewInstance().GetHashCode());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equality_Operator()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Succeed((Match<GenericParameterHelper>)null == null),
                                                EqualityTest.Fail(NewInstance() == null),
                                                EqualityTest.Fail(null == NewInstance()),
                                                EqualityTest.Succeed(NewInstance() == NewInstance()),
                                                EqualityTest.Fail(NewInstance() == NewDummy()),
                                                EqualityTest.Fail(NewDummy() == NewInstance()))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Inequality_Operator()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail((Match<GenericParameterHelper>)null != null),
                                                EqualityTest.Succeed(NewInstance() != null),
                                                EqualityTest.Succeed(null != NewInstance()),
                                                EqualityTest.Fail(NewInstance() != NewInstance()),
                                                EqualityTest.Succeed(NewInstance() != NewDummy()),
                                                EqualityTest.Succeed(NewDummy() != NewInstance()))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Type_Specific_Equals_Method()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance().Equals(null)),
                                                EqualityTest.Succeed(NewInstance().Equals(NewInstance())),
                                                EqualityTest.Fail(NewInstance().Equals(NewDummy())))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equals_Method()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance().Equals((object)null)),
                                                EqualityTest.Succeed(NewInstance().Equals((object)NewInstance())),
                                                EqualityTest.Fail(NewInstance().Equals((object)NewDummy())))
                                      .Succeeds());
        }

        private static Match<GenericParameterHelper> NewInstance()
        {
            return Match.NotNull<GenericParameterHelper>();
        }

        private static Match<GenericParameterHelper> NewDummy()
        {
            return Match.Custom(new MatchDummy<GenericParameterHelper>());
        }
    }
}
