using Lamar;
using PipelineFramework.Abstractions;

namespace PipelineFramework.Lamar
{
    public abstract class PipelineRegistryBase : ServiceRegistry
    {
        protected PipelineRegistryBase()
        { 
            For<IPipelineComponentResolver>().Use<PipelineComponentResolver>().Singleton();
        }
    }
}
