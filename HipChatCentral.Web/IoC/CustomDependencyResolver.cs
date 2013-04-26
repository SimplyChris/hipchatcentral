using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace HipChatCentral.Web.IoC
{
    public class CustomDependencyResolver : IDependencyResolver 
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;
            
            return ObjectFactory.TryGetInstance(serviceType);            
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {            
            return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
        }
    }
}