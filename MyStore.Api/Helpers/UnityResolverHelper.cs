using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace MyStore.Api.Helpers
{
    public class UnityResolverHelper : IDependencyResolver
    {
        protected IUnityContainer container;
        public UnityResolverHelper(UnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentException("container");
            }

            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}