﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ObjectFluentAssertionExtensions.cs" company="">
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
    using System;

    using NFluent.Extensions;
    using NFluent.Helpers;

    /// <summary>
    /// Provides assertion methods to be executed on an object instance.
    /// </summary>
    public static class ObjectFluentAssertionExtensions
    {
        // TODO: add IsNull()

        /// <summary>
        /// Checks that the actual value is equal to another expected value.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual value is not equal to the expected value.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<object>> IsEqualTo(this IFluentAssertion<object> fluentAssertion, object expected)
        {
            var assertionRunner = fluentAssertion as IFluentAssertionRunner<object>;
            var runnableAssertion = fluentAssertion as IRunnableAssertion<object>;

            return assertionRunner.ExecuteAssertion(
                () =>
                    {
                        EqualityHelper.IsEqualTo(runnableAssertion.Value, expected);
                    },
                EqualityHelper.BuildErrorMessage(runnableAssertion.Value, expected, true));
        }

        /// <summary>
        /// Checks that the actual value is not equal to another expected value.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual value is equal to the expected value.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<object>> IsNotEqualTo(this IFluentAssertion<object> fluentAssertion, object expected)
        {
            var assertionRunner = fluentAssertion as IFluentAssertionRunner<object>;
            var runnableAssertion = fluentAssertion as IRunnableAssertion<object>;

            return assertionRunner.ExecuteAssertion(
                () =>
                    {
                        EqualityHelper.IsNotEqualTo(runnableAssertion.Value, expected);
                    },
                EqualityHelper.BuildErrorMessage(runnableAssertion.Value, expected, false));
        }

        /// <summary>
        /// Checks that the actual instance is an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The expected Type of the instance.</typeparam>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual instance is not of the provided type.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<object>> IsInstanceOf<T>(this IFluentAssertion<object> fluentAssertion)
        {
            var assertionRunner = fluentAssertion as IFluentAssertionRunner<object>;
            var runnableAssertion = fluentAssertion as IRunnableAssertion<object>;

            return assertionRunner.ExecuteAssertion(
                () =>
                {
                    IsInstanceHelper.IsInstanceOf(runnableAssertion.Value, typeof(T));
                },
                IsInstanceHelper.BuildErrorMessage(runnableAssertion, typeof(T), true));
        }

        /// <summary>
        /// Checks that the actual instance is an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The expected Type of the instance.</typeparam>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual instance is not of the provided type.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<object>> IsNotInstanceOf<T>(this IFluentAssertion<object> fluentAssertion)
        {
            var assertionRunner = fluentAssertion as IFluentAssertionRunner<object>;
            var runnableAssertion = fluentAssertion as IRunnableAssertion<object>;

            return assertionRunner.ExecuteAssertion(
                () =>
                {
                    IsInstanceHelper.IsNotInstanceOf(runnableAssertion.Value, typeof(T));
                },
                string.Format("\nThe actual value:\n\t[{0}]\nis not an instance of:\n\t[{1}]\nbut an instance of:\n\t[{2}]\ninstead.", runnableAssertion.Value.ToStringProperlyFormated(), typeof(T), runnableAssertion.Value.GetType()));
        }

        /// <summary>
        /// Checks that the actual expression is in the inheritance hierarchy of the given type or of the same type.
        /// </summary>
        /// <typeparam name="T">The Type which is expected to be a base Type of the actual expression.</typeparam>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The checked expression is not in the inheritance hierarchy of the given type.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<object>> InheritsFrom<T>(this IFluentAssertion<object> fluentAssertion)
        {
            var assertionRunner = fluentAssertion as IFluentAssertionRunner<object>;
            var runnableAssertion = fluentAssertion as IRunnableAssertion<object>;

            Type instanceType = runnableAssertion.Value.GetTypeWithoutThrowingException();
            Type expectedBaseType = typeof(T);

            return assertionRunner.ExecuteAssertion(
                () =>
                {
                    IsInstanceHelper.InheritsFrom(runnableAssertion.Value, expectedBaseType);
                },
                string.Format("\nThe checked expression is part of the inheritance hierarchy or of the same type than the specified one.\nIndeed, checked expression type:\n\t[{0}]\nis a derived type of\n\t[{1}].", instanceType.ToStringProperlyFormated(), expectedBaseType.ToStringProperlyFormated()));
        }
    }
}
