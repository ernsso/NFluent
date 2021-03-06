﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INegated.cs" company="">
// //   Copyright 2013 Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    /// <summary>
    /// Indicates whether the fluent assertion is negated or not.
    /// </summary>
    public interface INegated
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="FluentAssertion{T}" /> should be negated or not.
        /// This property is useful when you implement assertion methods. 
        /// </summary>
        /// <value>
        ///   <c>true</c> if all the methods applying to this assertion instance should be negated; <c>false</c> otherwise.
        /// </value>
        bool Negated { get; }
    }
}