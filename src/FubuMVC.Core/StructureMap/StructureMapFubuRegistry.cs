using FubuCore;
using FubuMVC.Core.Runtime;
using StructureMap.Configuration.DSL;

namespace FubuMVC.Core.StructureMap
{
    public class StructureMapFubuRegistry : Registry
    {
        public StructureMapFubuRegistry()
        {
            For<IServiceLocator>().Use<StructureMapServiceLocator>();

            For<ISessionState>().Use<SimpleSessionState>();
        }

    }
}