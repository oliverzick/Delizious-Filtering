#region Copyright and license
// <copyright file="NotEqualTests.cs" company="Oliver Zick">
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
    public sealed class NotEqualTests
    {
        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_Is_Null_And_Reference_Is_An_Instance_Of_A_Reference_Type()
        {
            Assert.IsTrue(NewInstance(new object()).Matches(null));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_The_Same_Instance_Of_A_Reference_Type()
        {
            var obj = new object();

            Assert.IsFalse(NewInstance(obj).Matches(obj));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Different_Instances_Of_A_Reference_Type()
        {
            Assert.IsTrue(NewInstance(new object()).Matches(new object()));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_Is_Null_And_Reference_Is_An_Instance_Of_A_Reference_Type_With_Value_Semantics()
        {
            Assert.IsTrue(NewInstance(new GenericParameterHelper()).Matches(null));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_The_Same_Instance_Of_A_Reference_Type_With_Value_Semantics()
        {
            var obj = new GenericParameterHelper(1);

            Assert.IsFalse(NewInstance(obj).Matches(obj));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_Equal_Instances_Of_A_Reference_Type_With_Value_Semantics()
        {
            Assert.IsFalse(NewInstance(new GenericParameterHelper(1)).Matches(new GenericParameterHelper(1)));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Unequal_Instances_Of_A_Reference_Type_With_Value_Semantics()
        {
            Assert.IsTrue(NewInstance(new GenericParameterHelper(1)).Matches(new GenericParameterHelper(0)));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_Equal_Instances_Of_A_Value_Type()
        {
            Assert.IsFalse(NewInstance(1).Matches(1));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Unequal_Instances_Of_A_Value_Type()
        {
            Assert.IsTrue(NewInstance(1).Matches(0));
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
            Assert.AreEqual(NewInstance(1).GetHashCode(), NewInstance(1).GetHashCode());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equality_Operator()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Succeed((Match<int>)null == null),
                                                EqualityTest.Fail(NewInstance(1) == null),
                                                EqualityTest.Fail(null == NewInstance(1)),
                                                EqualityTest.Succeed(NewInstance(1) == NewInstance(1)),
                                                EqualityTest.Fail(NewInstance(1) == NewInstance(0)),
                                                EqualityTest.Fail(NewInstance(1) == NewDummy<int>()),
                                                EqualityTest.Fail(NewDummy<int>() == NewInstance(1)))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Inequality_Operator()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail((Match<int>)null != null),
                                                EqualityTest.Succeed(NewInstance(1) != null),
                                                EqualityTest.Succeed(null != NewInstance(1)),
                                                EqualityTest.Fail(NewInstance(1) != NewInstance(1)),
                                                EqualityTest.Succeed(NewInstance(1) != NewInstance(0)),
                                                EqualityTest.Succeed(NewInstance(1) != NewDummy<int>()),
                                                EqualityTest.Succeed(NewDummy<int>() != NewInstance(1)))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Type_Specific_Equals_Method()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance(1).Equals(null)),
                                                EqualityTest.Succeed(NewInstance(1).Equals(NewInstance(1))),
                                                EqualityTest.Fail(NewInstance(1).Equals(NewInstance(0))),
                                                EqualityTest.Fail(NewInstance(1).Equals(NewDummy<int>())))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equals_Method()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance(1).Equals((object)null)),
                                                EqualityTest.Succeed(NewInstance(1).Equals((object)NewInstance(1))),
                                                EqualityTest.Fail(NewInstance(1).Equals((object)NewInstance(0))),
                                                EqualityTest.Fail(NewInstance(1).Equals((object)NewDummy<int>())))
                                      .Succeeds());
        }

        private static Match<T> NewInstance<T>(T reference)
        {
            return Match.NotEqual(reference);
        }

        private static Match<T> NewDummy<T>()
        {
            return Match.Custom(new MatchDummy<T>());
        }
    }
}
