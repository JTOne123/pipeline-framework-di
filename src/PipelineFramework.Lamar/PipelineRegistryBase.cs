using Lamar;
using PipelineFramework.Abstractions;

namespace PipelineFramework.Lamar
{
    public class PipelineComponentResolverRegistryBase : ServiceRegistry
    {
        public PipelineComponentResolverRegistryBase()
        { 
            For<IPipelineComponentResolver>().Use<PipelineComponentResolver>().Singleton();
        }
    }
}
