#region Copyright and license
// // <copyright file="IMatch.cs" company="Oliver Zick">
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
    /// <summary>
    /// Represents a strongly typed match that provides a method to determine whether a value matches with.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value to match.
    /// </typeparam>
    public interface IMatch<in T>
    {
        /// <summary>
        /// Determines whether the specified <paramref name="value"/> successfully matches with this match instance.
        /// </summary>
        /// <param name="value">
        /// The value to match.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="value"/> successfully matches with this match instance; otherwise, <c>false</c>.
        /// </returns>
        bool Matches(T value);
    }
}
