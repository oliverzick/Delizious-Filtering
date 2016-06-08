#region Copyright and license
// <copyright file="GreaterThan.cs" company="Oliver Zick">
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

    internal sealed class GreaterThan<T> : IMatch<T>, IEquatable<GreaterThan<T>>
        where T : IComparable<T>
    {
        private readonly T reference;

        public GreaterThan(T reference)
        {
            this.reference = reference;
        }

        public bool Matches(T value)
        {
            return this.reference.CompareTo(value) < 0;
        }

        public override int GetHashCode()
        {
            return this.reference.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as GreaterThan<T>);
        }

        public bool Equals(GreaterThan<T> other)
        {
            return ValueSemantics.Determine(other, this.ValueEquals);
        }

        private bool ValueEquals(GreaterThan<T> other)
        {
            return this.reference.Equals(other.reference);
        }
    }
}
