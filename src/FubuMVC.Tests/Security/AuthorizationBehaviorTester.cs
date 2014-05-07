using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.Security;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Tests.Security
{
    [TestFixture]
    public class when_authorization_returns_allow : InteractionContext<AuthorizationBehavior>
    {
        protected override void beforeEach()
        {
            var request = MockFor<IFubuRequestContext>();


            MockFor<IAuthorizationNode>().Stub(x => x.IsAuthorized(request)).Return(AuthorizationRight.Allow);
            ClassUnderTest.InsideBehavior = MockFor<IActionBehavior>();
            ClassUnderTest.Invoke();
        }

        [Test]
        public void should_call_into_the_next_behavior()
        {
            MockFor<IActionBehavior>().AssertWasCalled(x => x.Invoke());
        }

        [Test]
        public void should_NOT_call_the_authorization_failure_handler()
        {
            MockFor<IAuthorizationFailureHandler>().AssertWasNotCalled(x => x.Handle());
        }
    }

    [TestFixture]
    public class when_authorization_returns_none : InteractionContext<AuthorizationBehavior>
    {
        protected override void beforeEach()
        {
            var request = MockFor<IFubuRequestContext>();

            MockFor<IAuthorizationNode>().Stub(x => x.IsAuthorized(request)).Return(AuthorizationRight.None);

            ClassUnderTest.InsideBehavior = MockFor<IActionBehavior>();
            ClassUnderTest.Invoke();
        }

        [Test]
        public void should_NOT_call_into_the_next_behavior()
        {
            MockFor<IActionBehavior>().AssertWasNotCalled(x => x.Invoke());
        }

        [Test]
        public void should_call_the_authorization_failure_handler()
        {
            MockFor<IAuthorizationFailureHandler>().AssertWasCalled(x => x.Handle());
        }
    }


    [TestFixture]
    public class when_authorization_returns_deny : InteractionContext<AuthorizationBehavior>
    {
        protected override void beforeEach()
        {
            var request = MockFor<IFubuRequestContext>();

            MockFor<IAuthorizationNode>().Stub(x => x.IsAuthorized(request)).Return(AuthorizationRight.Deny);

            ClassUnderTest.InsideBehavior = MockFor<IActionBehavior>();
            ClassUnderTest.Invoke();
        }

        [Test]
        public void should_NOT_call_into_the_next_behavior()
        {
            MockFor<IActionBehavior>().AssertWasNotCalled(x => x.Invoke());
        }

        [Test]
        public void should_call_the_authorization_failure_handler()
        {
            MockFor<IAuthorizationFailureHandler>().AssertWasCalled(x => x.Handle());
        }
    }
}