using System;
using Lamar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PipelineFramework.Abstractions;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using PipelineFramework.Tests.SharedInfrastructure;

namespace PipelineFramework.Lamar.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PipelineComponentResolverTests
    {
        private readonly IContainer _container;

        public PipelineComponentResolverTests()
        {
            
            _container = new Container(registry => registry.For<IPipelineComponent<TestPayload>>().Add<FooComponent>().Named(typeof(FooComponent).Name));
        }

        [TestMethod]
        public void PipelineComponentResolver_CtorNullFactoryTest()
        {
            Action act = () =>
           {
               // ReSharper disable once UnusedVariable
               var resolver = new PipelineComponentResolver(null);
           };

            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [TestMethod]
        public void PipelineComponentResolver_GetInstanceTest()
        {
            var target = new PipelineComponentResolver(_container);
            var result = target.GetInstance<IPipelineComponent<TestPayload>>(typeof(FooComponent).Name);

            result.Should().NotBeNull();
            result.Should().BeAssignableTo<FooComponent>();
        }
    }
}
