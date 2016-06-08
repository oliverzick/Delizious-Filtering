#region Copyright and license
// <copyright file="SameTests.cs" company="Oliver Zick">
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
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class SameTests
    {
        [TestMethod]
        public void Match_Fails_When_Value_To_Match_Is_Null_But_Reference_Is_An_Instance()
        {
            Assert.IsFalse(NewInstance(new GenericParameterHelper()).Matches(null));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_Different_Instances()
        {
            Assert.IsFalse(NewInstance(new GenericParameterHelper()).Matches(new GenericParameterHelper()));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Same_Instance()
        {
            var obj = new GenericParameterHelper();

            Assert.IsTrue(NewInstance(obj).Matches(obj));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Exception_On_Creation_When_Reference_Is_Null()
        {
            NewInstance<GenericParameterHelper>(null);
        }

        [TestMethod]
        public void Ensure_Equal_Hash_Code_For_Equal_Instances()
        {
            var reference = new object();

            Assert.AreEqual(NewInstance(reference).GetHashCode(), NewInstance(reference).GetHashCode());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equality_Operator()
        {
            var reference = new object();
            var otherReference = new object();

            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Succeed((Match<object>)null == null),
                                                EqualityTest.Fail(NewInstance(reference) == null),
                                                EqualityTest.Fail(null == NewInstance(reference)),
                                                EqualityTest.Succeed(NewInstance(reference) == NewInstance(reference)),
                                                EqualityTest.Fail(NewInstance(reference) == NewInstance(otherReference)),
                                                EqualityTest.Fail(NewInstance(reference) == NewDummy<object>()),
                                                EqualityTest.Fail(NewDummy<object>() == NewInstance(reference)))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Inequality_Operator()
        {
            var reference = new object();
            var otherReference = new object();

            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail((Match<object>)null != null),
                                                EqualityTest.Succeed(NewInstance(reference) != null),
                                                EqualityTest.Succeed(null != NewInstance(reference)),
                                                EqualityTest.Fail(NewInstance(reference) != NewInstance(reference)),
                                                EqualityTest.Succeed(NewInstance(reference) != NewInstance(otherReference)),
                                                EqualityTest.Succeed(NewInstance(reference) != NewDummy<object>()),
                                                EqualityTest.Succeed(NewDummy<object>() != NewInstance(reference)))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Type_Specific_Equals_Method()
        {
            var reference = new object();
            var otherReference = new object();

            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance(reference).Equals(null)),
                                                EqualityTest.Succeed(NewInstance(reference).Equals(NewInstance(reference))),
                                                EqualityTest.Fail(NewInstance(reference).Equals(NewInstance(otherReference))),
                                                EqualityTest.Fail(NewInstance(reference).Equals(NewDummy<object>())))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equals_Method()
        {
            var reference = new object();
            var otherReference = new object();

            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance(reference).Equals((object)null)),
                                                EqualityTest.Succeed(NewInstance(reference).Equals((object)NewInstance(reference))),
                                                EqualityTest.Fail(NewInstance(reference).Equals((object)NewInstance(otherReference))),
                                                EqualityTest.Fail(NewInstance(reference).Equals((object)NewDummy<object>())))
                                      .Succeeds());
        }

        private static Match<T> NewInstance<T>(T reference)
            where T : class 
        {
            return Match.Same(reference);
        }

        private static Match<T> NewDummy<T>()
        {
            return Match.Custom(new MatchDummy<T>());
        }
    }
}
