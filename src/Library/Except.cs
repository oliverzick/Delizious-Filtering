#region Copyright and license
// <copyright file="Except.cs" company="Oliver Zick">
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

    internal sealed class Except<T> : IMatch<T>, IEquatable<Except<T>>
    {
        private readonly Collection<IMatch<T>> matches;

        private Except(Collection<IMatch<T>> matches)
        {
            this.matches = matches;
        }

        public static Except<T> Create(params IMatch<T>[] matches)
        {
            return new Except<T>(Collection<IMatch<T>>.Create(matches));
        }

        public bool Matches(T value)
        {
            return this.matches.All(match => !match.Matches(value));
        }

        public override int GetHashCode()
        {
            return this.matches.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Except<T>);
        }

        public bool Equals(Except<T> other)
        {
            return ValueSemantics.Determine(other, this.ValueEquals);
        }

        private bool ValueEquals(Except<T> other)
        {
            return this.matches.Equals(other.matches);
        }
    }
}
