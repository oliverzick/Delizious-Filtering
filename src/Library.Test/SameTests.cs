#region Copyright and license
// // <copyright file="SameTests.cs" company="Oliver Zick">
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class SameTests
    {
        [TestMethod]
        public void Match_Null__With_Null__Should_Return_True()
        {
            Assert.IsTrue(Match.Same<GenericParameterHelper>(null).Matches(null));
        }

        [TestMethod]
        public void Match_Null__With_An_Instance__Should_Return_False()
        {
            Assert.IsFalse(Match.Same<GenericParameterHelper>(null).Matches(new GenericParameterHelper()));
        }

        [TestMethod]
        public void Match_An_Instance__With_Null__Should_Return_False()
        {
            Assert.IsFalse(Match.Same(new GenericParameterHelper()).Matches(null));
        }

        [TestMethod]
        public void Match_An_Instance__With_Different_Instance__Should_Return_False()
        {
            Assert.IsFalse(Match.Same(new GenericParameterHelper()).Matches(new GenericParameterHelper()));
        }

        [TestMethod]
        public void Match_An_Instance__With_Same_Instance__Should_Return_True()
        {
            var obj = new GenericParameterHelper();

            Assert.IsTrue(Match.Same(obj).Matches(obj));
        }
    }
}
