#region Copyright and license
// <copyright file="Collection.cs" company="Oliver Zick">
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

    internal sealed class Collection<T> : IEquatable<Collection<T>>
    {
        private readonly T[] items;

        private Collection(T[] items)
        {
            this.items = items;
        }

        public static Collection<T> Create(T[] items)
        {
            return new Collection<T>(items);
        }

        public bool All(Func<T, bool> predicate)
        {
            return this.items.All(predicate);
        }

        public override int GetHashCode()
        {
            return HashCode.Calculate(this.items.Select(item => item.GetHashCode()));
        }

        public bool Equals(Collection<T> other)
        {
            return ValueSemantics.Determine(other, this.ValueEquals);
        }

        private bool ValueEquals(Collection<T> other)
        {
            return this.items.SequenceEqual(other.items);
        }
    }
}