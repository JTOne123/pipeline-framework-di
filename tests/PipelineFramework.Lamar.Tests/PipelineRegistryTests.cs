using FluentAssertions;
using Lamar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PipelineFramework.Abstractions;
using PipelineFramework.Lamar.Tests.Infrastructure;
using PipelineFramework.Tests.SharedInfrastructure;
using System.Diagnostics.CodeAnalysis;

namespace PipelineFramework.Lamar.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PipelineCompositionRootTests
    {
        private readonly IContainer _container;

        public PipelineCompositionRootTests()
        {
            _container = new Container(new TestPipelineRegistry());
        }

        [TestMethod]
        public void PipelineCompositionRoot_GetPipeline()
        {
            var result = _container.GetInstance<IPipeline<TestPayload>>();

            result.Should().NotBeNull();
        }

        [TestMethod]
        public void PipelineCompositionRoot_GetAsyncPipeline()
        {
            var result = _container.GetInstance<IAsyncPipeline<TestPayload>>();

            result.Should().NotBeNull();
        }
    }
}
