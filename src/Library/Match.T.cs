#region Copyright and license
// <copyright file="Match.T.cs" company="Oliver Zick">
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

    /// <summary>
    /// Represents a strongly typed match that provides a method to determine whether a value matches with.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value to match.
    /// </typeparam>
    public sealed class Match<T> : IMatch<T>, IEquatable<Match<T>>
    {
        private readonly IMatch<T> match;

        private Match(IMatch<T> match)
        {
            this.match = match;
        }

        internal static Match<T> Create(IMatch<T> match)
        {
            return new Match<T>(match);
        }

        internal static Match<T> All(params Match<T>[] matches)
        {
            return Create(All<T>.Create(matches.Select(match => match.match).ToArray()));
        }

        internal static Match<T> Any(params Match<T>[] matches)
        {
            return Create(Any<T>.Create(matches.Select(match => match.match).ToArray()));
        }

        internal static Match<T> Except(params Match<T>[] matches)
        {
            return Create(new Except<T>(matches.Select(match => match.match).ToArray()));
        }

        public static bool operator ==(Match<T> left, Match<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Match<T> left, Match<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified <paramref name="value"/> successfully matches with this match instance.
        /// </summary>
        /// <param name="value">
        /// The value to match.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="value"/> successfully matches with this match instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Matches(T value)
        {
            return this.match.Matches(value);
        }

        public override int GetHashCode()
        {
            return this.match.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Match<T>);
        }

        public bool Equals(Match<T> other)
        {
            return ValueSemantics.Determine(other, this.ValueEquals);
        }

        private bool ValueEquals(Match<T> other)
        {
            return this.match.Equals(other.match);
        }
    }
}
