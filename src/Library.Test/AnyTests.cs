#region Copyright and license
// <copyright file="AnyTests.cs" company="Oliver Zick">
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
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class AnyTests
    {
        [TestMethod]
        public void Match_Fails_When_No_Matches_Are_Given()
        {
            Assert.IsFalse(Match.Any<int>().Matches(1));
        }

        [TestMethod]
        public void Match_Succeeds_When_All_Matches_Succeed()
        {
            Assert.IsTrue(Match.Any(Match.Custom(new MatchStub(1)),
                                    Match.Custom(new MatchStub(1)),
                                    Match.Custom(new MatchStub(1))).Matches(1));
        }

        [TestMethod]
        public void Match_Succeeds_When_At_Least_One_Match_Succeeds()
        {
            Assert.IsTrue(Match.Any(Match.Custom(new MatchStub(0)),
                                    Match.Custom(new MatchStub(1)),
                                    Match.Custom(new MatchStub(0))).Matches(1));
        }

        [TestMethod]
        public void Match_Fails_When_All_Matches_Fail()
        {
            Assert.IsFalse(Match.Any(Match.Custom(new MatchStub(0)),
                                     Match.Custom(new MatchStub(0)),
                                     Match.Custom(new MatchStub(0))).Matches(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Exception_On_Creation_When_Matches_Are_Null()
        {
            Match.Any<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throws_Exception_On_Creation_When_Matches_Contain_At_Least_One_Null_Reference()
        {
            Match.Any(Match.Always<int>(), null);
        }

        [TestMethod]
        public void Ensure_Equal_Hash_Code_For_Equal_Instances()
        {
            Assert.AreEqual(NewInstance(1, 2, 3).GetHashCode(), NewInstance(1, 2, 3).GetHashCode());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equality_Operator()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Succeed((Match<int>)null == null),
                                                EqualityTest.Fail(NewInstance(1, 2, 3) == null),
                                                EqualityTest.Fail(null == NewInstance(1, 2, 3)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3) == NewInstance(1, 2, 3)),
                                                EqualityTest.Fail(NewInstance(1, 2, 3) == NewInstance(1, 3, 2)),
                                                EqualityTest.Fail(NewInstance(1, 2, 3) == NewInstance(1, 2, 3, 4)),
                                                EqualityTest.Fail(NewInstance(1, 2, 3) == NewInstance(1, 2)),
                                                EqualityTest.Fail(NewInstance(1, 2, 3) == NewDummy()),
                                                EqualityTest.Fail(NewDummy() == NewInstance(1, 2, 3)))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Inequality_Operator()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail((Match<int>)null != null),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3) != null),
                                                EqualityTest.Succeed(null != NewInstance(1, 2, 3)),
                                                EqualityTest.Fail(NewInstance(1, 2, 3) != NewInstance(1, 2, 3)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3) != NewInstance(1, 3, 2)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3) != NewInstance(1, 2, 3, 4)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3) != NewInstance(1, 2)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3) != NewDummy()),
                                                EqualityTest.Succeed(NewDummy() != NewInstance(1, 2, 3)))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Type_Specific_Equals_Method()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance(1, 2, 3).Equals(null)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3).Equals(NewInstance(1, 2, 3))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals(NewInstance(1, 3, 2))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals(NewInstance(1, 2, 3, 4))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals(NewInstance(1, 2))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals(NewDummy())))
                                      .Succeeds());
        }

        [TestMethod]
        public void Ensure_Value_Semantics_Using_Equals_Method()
        {
            Assert.IsTrue(EqualityTest.Multiple(EqualityTest.Fail(NewInstance(1, 2, 3).Equals((object)null)),
                                                EqualityTest.Succeed(NewInstance(1, 2, 3).Equals((object)NewInstance(1, 2, 3))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals((object)NewInstance(1, 3, 2))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals((object)NewInstance(1, 2, 3, 4))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals((object)NewInstance(1, 2))),
                                                EqualityTest.Fail(NewInstance(1, 2, 3).Equals((object)NewDummy())))
                                      .Succeeds());
        }

        private static Match<int> NewInstance(params Match<int>[] matches)
        {
            return Match.Any(matches);
        }

        private static Match<int> NewInstance(params int[] references)
        {
            return NewInstance(references.Select(reference => Match.Custom(new MatchStub(reference))).ToArray());
        }

        private static Match<int> NewDummy()
        {
            return Match.Custom(new MatchDummy<int>());
        }
    }
}
