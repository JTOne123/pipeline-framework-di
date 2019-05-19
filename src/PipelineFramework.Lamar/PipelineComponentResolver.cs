using Lamar;
using PipelineFramework.Abstractions;
using System;

namespace PipelineFramework.Lamar
{
    public class PipelineComponentResolver : IPipelineComponentResolver
    {
        private readonly IServiceContext _serviceContext;

        public PipelineComponentResolver(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext ?? throw new ArgumentNullException(nameof(serviceContext));
        }

        public T GetInstance<T>(string name) where T : IPipelineComponent
        {
            return _serviceContext.GetInstance<T>(name); 
        }
    }
}
