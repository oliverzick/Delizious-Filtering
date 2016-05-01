#region Copyright and license
// // <copyright file="Match.cs" company="Oliver Zick">
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

    public static class Match
    {
        public static Match<T> Always<T>()
        {
            return Match<T>.Create(new Always<T>());
        }

        public static Match<T> Never<T>()
        {
            return Match<T>.Create(new Never<T>());
        }

        public static Match<T> Any<T>()
        {
            return Match<T>.Create(new Any<T>());
        }

        public static Match<T> Null<T>()
            where T : class
        {
            return Match<T>.Create(new Null<T>());
        }

        public static Match<T> Same<T>(T reference)
            where T : class
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference), "When matching an instance to be a null reference use Match.Null<T>() instead.");
            }

            return Match<T>.Create(new Same<T>(reference));
        }

        public static Match<T> Equal<T>(T reference)
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference), "When matching an instance to be a null reference use Match.Null<T>() instead.");
            }

            return Match<T>.Create(new Equal<T>(reference));
        }

        public static Match<T> GreaterThan<T>(T reference)
            where T : IComparable<T>
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference));
            }

            return Match<T>.Create(new GreaterThan<T>(reference));
        }

        public static Match<T> GreaterThanOrEqualTo<T>(T reference)
            where T : IComparable<T>
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference));
            }

            return Match<T>.Create(new GreaterThanOrEqualTo<T>(reference));
        }

        public static Match<T> LessThan<T>(T reference)
            where T : IComparable<T>
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference));
            }

            return Match<T>.Create(new LessThan<T>(reference));
        }
    }
}
