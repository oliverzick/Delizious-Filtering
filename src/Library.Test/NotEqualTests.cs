#region Copyright and license
// // <copyright file="NotEqualTests.cs" company="Oliver Zick">
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
    public sealed class NotEqualTests
    {
        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_Is_Null_And_Reference_Is_An_Instance_Of_A_Reference_Type()
        {
            Assert.IsTrue(Match.NotEqual(new object()).Matches(null));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_The_Same_Instance_Of_A_Reference_Type()
        {
            var obj = new object();

            Assert.IsFalse(Match.NotEqual(obj).Matches(obj));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Different_Instances_Of_A_Reference_Type()
        {
            Assert.IsTrue(Match.NotEqual(new object()).Matches(new object()));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_Is_Null_And_Reference_Is_An_Instance_Of_A_Reference_Type_With_Value_Semantics()
        {
            Assert.IsTrue(Match.NotEqual(new GenericParameterHelper()).Matches(null));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_The_Same_Instance_Of_A_Reference_Type_With_Value_Semantics()
        {
            var obj = new GenericParameterHelper(1);

            Assert.IsFalse(Match.NotEqual(obj).Matches(obj));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_Equal_Instances_Of_A_Reference_Type_With_Value_Semantics()
        {
            Assert.IsFalse(Match.NotEqual(new GenericParameterHelper(1)).Matches(new GenericParameterHelper(1)));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Unequal_Instances_Of_A_Reference_Type_With_Value_Semantics()
        {
            Assert.IsTrue(Match.NotEqual(new GenericParameterHelper(1)).Matches(new GenericParameterHelper(0)));
        }

        [TestMethod]
        public void Match_Fails_When_Value_To_Match_And_Reference_Are_Equal_Instances_Of_A_Value_Type()
        {
            Assert.IsFalse(Match.NotEqual(1).Matches(1));
        }

        [TestMethod]
        public void Match_Succeeds_When_Value_To_Match_And_Reference_Are_Unequal_Instances_Of_A_Value_Type()
        {
            Assert.IsTrue(Match.NotEqual(1).Matches(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Exception_On_Creation_When_Reference_Is_Null()
        {
            Match.NotEqual<GenericParameterHelper>(null);
        }
    }
}
