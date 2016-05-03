﻿#region Copyright and license
// // <copyright file="NotNullTests.cs" company="Oliver Zick">
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
    public sealed class NotNullTests
    {
        [TestMethod]
        public void Fail__When_Value_Is_Null()
        {
            Assert.IsFalse(Match.NotNull<GenericParameterHelper>().Matches(null));
        }

        [TestMethod]
        public void Succeed__When_Value_Is_An_Instance()
        {
            Assert.IsTrue(Match.NotNull<GenericParameterHelper>().Matches(new GenericParameterHelper()));
        }
    }
}
