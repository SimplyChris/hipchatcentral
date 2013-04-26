using System;
using HipChatCentral.Domain.Data.Contexts;
using HipChatCentral.Domain.Interfaces;
using HipChatCentral.Domain.Services;
using HipChatCentral.Domain.Services.Logging;
using StructureMap.Configuration.DSL;

namespace HipChatCentral.Domain.Registries
{
    public class DomainRegistry : Registry
    {
         public DomainRegistry ()
         {
             For<IHipChatCentralContext>().Use<HipChatCentralContext>();
             For(typeof (IRepository<>)).Use(typeof (Repository<>));
             For<ILogConfigurator>().Use<Log4NetConfigurator>();
             For(typeof (ICustomLogger<>)).Use(typeof (Log4NetLogger<>));
         }
    }
}