#region Copyright and license
// // <copyright file="EqualTests.cs" company="Oliver Zick">
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
    public sealed class EqualTests
    {
        [TestMethod]
        public void Fail__For_Reference_Type__When_Reference_Is_An_Instance_And_Value_Is_Null()
        {
            Assert.IsFalse(Match.Equal(new object()).Matches(null));
        }

        [TestMethod]
        public void Succeed__For_Reference_Type__When_Reference_And_Value_Are_Same()
        {
            var obj = new object();

            Assert.IsTrue(Match.Equal(obj).Matches(obj));
        }

        [TestMethod]
        public void Fail__For_Reference_Type__When_Reference_And_Value_Are_Not_Same()
        {
            Assert.IsFalse(Match.Equal(new object()).Matches(new object()));
        }

        [TestMethod]
        public void Fail__For_Reference_Type_With_Value_Semantics__When_Reference_Is_An_Instance_And_Value_Is_Null()
        {
            Assert.IsFalse(Match.Equal(new GenericParameterHelper()).Matches(null));
        }

        [TestMethod]
        public void Succeed__For_Reference_Type_With_Value_Semantics__When_Reference_And_Value_Are_Same()
        {
            var obj = new GenericParameterHelper(1);

            Assert.IsTrue(Match.Equal(obj).Matches(obj));
        }

        [TestMethod]
        public void Succeed__For_Reference_Type_With_Value_Semantics__When_Reference_And_Value_Are_Equal()
        {
            Assert.IsTrue(Match.Equal(new GenericParameterHelper(1)).Matches(new GenericParameterHelper(1)));
        }

        [TestMethod]
        public void Fail__For_Reference_Type_With_Value_Semantics__When_Reference_And_Value_Are_Unequal()
        {
            Assert.IsFalse(Match.Equal(new GenericParameterHelper(1)).Matches(new GenericParameterHelper(0)));
        }

        [TestMethod]
        public void Succeed__For_Value_Type__When_Reference_And_Value_Are_Equal()
        {
            Assert.IsTrue(Match.Equal(1).Matches(1));
        }

        [TestMethod]
        public void Fail__For_Value_Type__When_Reference_And_Value_Are_Unequal()
        {
            Assert.IsFalse(Match.Equal(1).Matches(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception__When_Reference_Is_Null()
        {
            Match.Equal<GenericParameterHelper>(null);
        }
    }
}
