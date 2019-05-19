using Lamar;
using PipelineFramework.Abstractions;
using PipelineFramework.Tests.SharedInfrastructure;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PipelineFramework.Lamar.Tests.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class TestPipelineRegistry : PipelineRegistryBase
    {
        public TestPipelineRegistry()
        {
            For<IAsyncPipelineComponent<TestPayload>>().Add<FooComponent>().Named(typeof(FooComponent).Name);
            For<IAsyncPipelineComponent<TestPayload>>().Add<BarComponent>().Named(typeof(BarComponent).Name);

            For<IPipelineComponent<TestPayload>>().Add<FooComponent>().Named(typeof(FooComponent).Name);
            For<IPipelineComponent<TestPayload>>().Add<BarComponent>().Named(typeof(BarComponent).Name);

            For<IDictionary<string, IDictionary<string, string>>>().Use(new Dictionary<string, IDictionary<string, string>>());

            For<IAsyncPipeline<TestPayload>>().Use(context =>
                PipelineBuilder<TestPayload>
                    .Async()
                    .WithComponent<FooComponent>()
                    .WithComponent<BarComponent>()
                    .WithComponentResolver(context.GetInstance<IPipelineComponentResolver>())
                    .WithSettings(context.GetInstance<IDictionary<string, IDictionary<string, string>>>())
                    .Build());

            For<IPipeline<TestPayload>>().Use(context =>
                PipelineBuilder<TestPayload>
                    .NonAsync()
                    .WithComponent<FooComponent>()
                    .WithComponent<BarComponent>()
                    .WithComponentResolver(context.GetInstance<IPipelineComponentResolver>())
                    .WithSettings(context.GetInstance<IDictionary<string, IDictionary<string, string>>>())
                    .Build());
        }
    }
}
