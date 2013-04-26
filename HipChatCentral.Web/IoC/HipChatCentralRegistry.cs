using System.Web.Mvc;
using StructureMap.Configuration.DSL;

namespace HipChatCentral.Web.IoC
{
    public class HipChatCentralRegistry : Registry 
    {
         public HipChatCentralRegistry ()
         {
             Scan(x=>
                      {
                          x.AssembliesFromApplicationBaseDirectory();
                          x.TheCallingAssembly();
                          x.WithDefaultConventions();
                      });
             For<IControllerFactory>().Use<CustomControllerFactory>();             
         }
    }
}