﻿using FubuMVC.Core;
using FubuMVC.Core.StructureMap;
using NUnit.Framework;

namespace FubuMVC.Localization.Testing
{
    [TestFixture]
    public class IntegratedBootstrappingTests
    {
        [Test]
        public void smoke()
        {
            new LocalizationApplication()
                .BuildApplication()
                .Bootstrap();
        }

        public class LocalizationApplication : IApplicationSource
        {
            public FubuApplication BuildApplication()
            {
                return FubuApplication
                    .For<LocalizationRegistry>();
            }
        }
        public class LocalizationRegistry : FubuRegistry
        {
            public LocalizationRegistry()
            {
                Import<BasicLocalizationSupport>();
            }
        }
    }
}