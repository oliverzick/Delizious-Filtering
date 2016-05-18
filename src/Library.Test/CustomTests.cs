#region Copyright and license
// <copyright file="CustomTests.cs" company="Oliver Zick">
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
    public sealed class CustomTests
    {
        [TestMethod]
        public void Match_Succeeds_When_Custom_Match_Succeeds()
        {
            Assert.IsTrue(Match.Custom(new MatchStub(1)).Matches(1));
        }

        [TestMethod]
        public void Match_Fails_When_Custom_Match_Fails()
        {
            Assert.IsFalse(Match.Custom(new MatchStub(1)).Matches(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Exception_On_Creation_When_Custom_Match_Is_Null()
        {
            Match.Custom<GenericParameterHelper>(null);
        }
    }
}
