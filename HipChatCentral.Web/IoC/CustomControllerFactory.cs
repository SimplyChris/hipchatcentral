using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using StructureMap;

namespace HipChatCentral.Web.IoC
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller;
            
            if (controllerType == null)
                return null;

            try
            {                
                controller = (IController)ObjectFactory.GetInstance(controllerType);
                return controller;                
            }
            
            catch (Exception ex)
            {
                var text = ObjectFactory.WhatDoIHave();
                return null;
            }            
       }
    }
}