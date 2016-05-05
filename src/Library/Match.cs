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
    using System.Linq;

    /// <summary>
    /// Provides static factory methods to create different kinds of <see cref="Match{T}"/> instances.
    /// </summary>
    public static class Match
    {
        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that always matches successfully regardless the value to match.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value to match.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that always matches successfully.
        /// </returns>
        public static Match<T> Always<T>()
        {
            return Match<T>.Create(new Always<T>());
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that never matches successfully regardless the value to match.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value to match.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that never matches successfully.
        /// </returns>
        public static Match<T> Never<T>()
        {
            return Match<T>.Create(new Never<T>());
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is a <c>null</c> reference.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value to match. This must be a reference type.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is a <c>null</c> reference.
        /// </returns>
        public static Match<T> Null<T>()
            where T : class
        {
            return Match<T>.Create(new Null<T>());
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is not a <c>null</c> reference.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value to match. This must be a reference type.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is not a <c>null</c> reference.
        /// </returns>
        public static Match<T> NotNull<T>()
            where T : class
        {
            return Match<T>.Create(new NotNull<T>());
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is the same instance as the specified <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">
        /// The instance a value to match must be the same to match successfully.
        /// </param>
        /// <typeparam name="T">
        /// The type of the value to match. This must be a reference type.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is the same instance as the specified <paramref name="reference"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reference"/> is <c>null</c>.
        /// When matching an instance to be a <c>null</c> reference use <see cref="Null{T}"/> instead.
        /// </exception>
        public static Match<T> Same<T>(T reference)
            where T : class
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference), "When matching an instance to be a null reference use Match.Null<T>() instead.");
            }

            return Match<T>.Create(new Same<T>(reference));
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is not the same instance as the specified <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">
        /// The instance a value to match must not be the same to match successfully.
        /// </param>
        /// <typeparam name="T">
        /// The type of the value to match. This must be a reference type.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is not the same instance as the specified <paramref name="reference"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reference"/> is <c>null</c>.
        /// When matching an instance to not be a <c>null</c> reference use <see cref="NotNull{T}"/> instead.
        /// </exception>
        public static Match<T> NotSame<T>(T reference)
            where T : class
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference), "When matching an instance to not be a null reference use Match.NotNull<T>() instead.");
            }

            return Match<T>.Create(new NotSame<T>(reference));
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match equals the specified <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">
        /// The instance a value to match must equal to match successfully.
        /// </param>
        /// <typeparam name="T">
        /// The type of the value to match.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match equals the specified <paramref name="reference"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reference"/> is <c>null</c>.
        /// When matching an instance to be a <c>null</c> reference use <see cref="Null{T}"/> instead.
        /// </exception>
        public static Match<T> Equal<T>(T reference)
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference), "When matching an instance to be a null reference use Match.Null<T>() instead.");
            }

            return Match<T>.Create(new Equal<T>(reference));
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is not equal to the specified <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">
        /// The instance a value to match must not equal to match successfully.
        /// </param>
        /// <typeparam name="T">
        /// The type of the value to match.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is not equal to the specified <paramref name="reference"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reference"/> is <c>null</c>.
        /// When matching an instance to not be a <c>null</c> reference use <see cref="NotNull{T}"/> instead.
        /// </exception>
        public static Match<T> NotEqual<T>(T reference)
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference), "When matching an instance to not be a null reference use Match.NotNull<T>() instead.");
            }

            return Match<T>.Create(new NotEqual<T>(reference));
        }

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is greater than the specified <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">
        /// The instance a value to match must be greater than to match successfully.
        /// </param>
        /// <typeparam name="T">
        /// The type of the value to match. This type must implement the <see cref="IComparable{T}"/> interface.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is greater than the specified <paramref name="reference"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reference"/> is <c>null</c>.
        /// </exception>
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

        /// <summary>
        /// Creates a <see cref="Match{T}"/> instance that matches successfully when the value to match is less than the specified <paramref name="reference"/>.
        /// </summary>
        /// <param name="reference">
        /// The instance a value to match must be less than to match successfully.
        /// </param>
        /// <typeparam name="T">
        /// The type of the value to match. This type must implement the <see cref="IComparable{T}"/> interface.
        /// </typeparam>
        /// <returns>
        /// A new <see cref="Match{T}"/> instance that determines whether the value to match is less than the specified <paramref name="reference"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="reference"/> is <c>null</c>.
        /// </exception>
        public static Match<T> LessThan<T>(T reference)
            where T : IComparable<T>
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference));
            }

            return Match<T>.Create(new LessThan<T>(reference));
        }

        public static Match<T> LessThanOrEqualTo<T>(T reference)
            where T : IComparable<T>
        {
            if (ReferenceEquals(reference, null))
            {
                throw new ArgumentNullException(nameof(reference));
            }

            return Match<T>.Create(new LessThanOrEqualTo<T>(reference));
        }

        public static Match<T> All<T>(params Match<T>[] matches)
        {
            if (ReferenceEquals(matches, null))
            {
                throw new ArgumentNullException(nameof(matches));
            }

            if (matches.Any(match => ReferenceEquals(match, null)))
            {
                throw new ArgumentException("At least one match is a null reference.", nameof(matches));
            }

            return Match<T>.All(matches);
        }

        public static Match<T> Any<T>(params Match<T>[] matches)
        {
            if (ReferenceEquals(matches, null))
            {
                throw new ArgumentNullException(nameof(matches));
            }

            if (matches.Any(match => ReferenceEquals(match, null)))
            {
                throw new ArgumentException("At least one match is a null reference.", nameof(matches));
            }

            return Match<T>.Any(matches);
        }

        public static Match<T> None<T>(params Match<T>[] matches)
        {
            if (ReferenceEquals(matches, null))
            {
                throw new ArgumentNullException(nameof(matches));
            }

            if (matches.Any(match => ReferenceEquals(match, null)))
            {
                throw new ArgumentException("At least one match is a null reference.", nameof(matches));
            }

            return Match<T>.None(matches);
        }
    }
}
