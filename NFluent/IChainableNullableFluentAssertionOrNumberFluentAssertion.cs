﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="IChainableNullableFluentAssertionOrNumberFluentAssertion.cs" company="">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides a way to chain two <see cref="IForkableFluentAssertion"/> instances or to chain.
    /// </summary>
    /// <typeparam name="N">Number type of the checked nullable.</typeparam>
    public interface IChainableNullableFluentAssertionOrNumberFluentAssertion<N> where N : struct
    {
        /// <summary>
        /// Chains a new fluent assertion on the current one for the nullable value.
        /// </summary>
        /// <value>
        /// The new fluent assertion instance dedicated to the nullable, which has been chained to the previous one.
        /// </value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here since we want to trick and improve the auto-completion experience here.")]
        IFluentAssertion<N?> And { get; }

        /// <summary>
        /// Chains a new <see cref="IFluentAssertion{N}"/> instance to the current assertion.
        /// </summary>
        /// <value>
        /// The new fluent assertion instance dedicated to the nullable Value, which has been chained to the previous one.
        /// </value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed. Suppression is OK here since we want to trick and improve the auto-completion experience here.")]
        IFluentAssertion<N> Which { get; }
    }
}