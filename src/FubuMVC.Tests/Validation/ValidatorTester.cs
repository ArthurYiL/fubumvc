﻿using FubuCore;
using FubuMVC.Core.Validation;
using FubuMVC.Tests.TestSupport;
using FubuMVC.Tests.Validation.Models;
using NUnit.Framework;
using Shouldly;

namespace FubuMVC.Tests.Validation
{
    [TestFixture]
    public class ValidatorTester : InteractionContext<Validator>
    {
        private SimpleModel theModel;
        private RecordingValidationRule theRecordingRule;
        private ValidationContext theContext;
        private ValidationGraph theGraph;

        protected override void beforeEach()
        {
            theModel = new SimpleModel();
            theRecordingRule = new RecordingValidationRule();

            var theSource = ConfiguredValidationSource.For(theModel.GetType(), theRecordingRule);
            theGraph = ValidationGraph.For(theSource);

            Services.Inject<ITypeResolver>(new TypeResolver());
            Services.Inject(theGraph);

            ClassUnderTest.Validate(theModel);

            theContext = theRecordingRule.Context;
        }

        [Test]
        public void sets_the_target_type()
        {
            theContext.TargetType.ShouldBe(theModel.GetType());
        }

        [Test]
        public void sets_the_type_resolver()
        {
            theContext.Resolver.ShouldBe(MockFor<ITypeResolver>());
        }

        [Test]
        public void sets_the_service_locator()
        {
            theContext.ServiceLocator.ShouldBe(MockFor<IServiceLocator>());
        }

        public class RecordingValidationRule : IValidationRule
        {
            public ValidationContext Context;

            public void Validate(ValidationContext context)
            {
                Context = context;
            }
        }
    }
}