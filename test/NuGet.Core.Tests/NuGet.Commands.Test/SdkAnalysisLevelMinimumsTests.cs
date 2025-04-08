// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using NuGet.Versioning;
using Xunit;

namespace NuGet.Commands.Test
{
    public class SdkAnalysisLevelMinimumsTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsEnabled_WhenSdkAnalysisLevelIsNullAndUsingMicrosoftNetSdkIsFalse_ShouldReturnTrue(bool nonSdkProjectDefault)
        {
            var result = SdkAnalysisLevelMinimums.IsEnabled(null, false, new NuGetVersion("9.0.100"), nonSdkProjectDefault);
            Assert.Equal(nonSdkProjectDefault, result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsEnabled_WhenSdkAnalysisLevelIsNullAndUsingMicrosoftNetSdkIsTrue_ShouldReturnFalse(bool nonSdkProjectDefault)
        {
            var result = SdkAnalysisLevelMinimums.IsEnabled(null, true, new NuGetVersion("9.0.100"), nonSdkProjectDefault);
            Assert.False(result);
        }

        [Fact]
        public void IsEnabled_WhenSdkAnalysisLevelIsLessThanMinSdkVersion_ShouldReturnFalse()
        {
            var result = SdkAnalysisLevelMinimums.IsEnabled(new NuGetVersion("8.0.900"), true, new NuGetVersion("9.0.100"), true);
            Assert.False(result);
        }

        [Fact]
        public void IsEnabled_WhenSdkAnalysisLevelIsEqualToMinSdkVersion_ShouldReturnTrue()
        {
            var result = SdkAnalysisLevelMinimums.IsEnabled(new NuGetVersion("9.0.100"), true, new NuGetVersion("9.0.100"), true);
            Assert.True(result);
        }

        [Fact]
        public void IsEnabled_WhenSdkAnalysisLevelIsGreaterThanMinSdkVersion_ShouldReturnTrue()
        {
            var result = SdkAnalysisLevelMinimums.IsEnabled(new NuGetVersion("9.0.101"), true, new NuGetVersion("9.0.100"), true);
            Assert.True(result);
        }
    }
}
