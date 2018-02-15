using System;
using CodingChallenge.Models.Validation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Tests
{
    [TestClass]
    public class ValidationExtensionTests
    {
        [TestMethod]
        public void Test_ValidationExtensions_ThrowIfNullOrEmpty_Strings()
        {
            string nullString = null;
            string paramName = "UNITTEST";

            Action act = null;

            act = () => "".ThrowIfNullOrEmpty(paramName);
            act.Should().Throw<ArgumentNullException>();

            act = () => String.Empty.ThrowIfNullOrEmpty(paramName);
            act.Should().Throw<ArgumentNullException>();

            act = () => nullString.ThrowIfNullOrEmpty(paramName);
            act.Should().Throw<ArgumentNullException>();

            act = () => "TEST".ThrowIfNullOrEmpty(paramName);
            act.Should().NotThrow();
        }

        [TestMethod]
        public void Test_ValidationExtensions_ThrowIfNullOrEmpty_Objects()
        {
            Object obj = null;
            string paramName = "UNITTEST";

            Action act = null;

            act = () => obj.ThrowIfNullOrEmpty(paramName);
            act.Should().Throw<ArgumentNullException>();

            act = () => new Object().ThrowIfNullOrEmpty(paramName);
            act.Should().NotThrow();
        }
    }
}