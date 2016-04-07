using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IQ.Santos.Ngo.Beertap.Services;

namespace IQ.Santos.Ngo.Beertap.WebApi.Infrastructure.Installers
{
    public class ApiDependenciesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IOfficeDataService>().ImplementedBy<DefaultOfficeDataService>());
            container.Register(Component.For<IBeerTapDataService>().ImplementedBy<DefaultBeerTapDataService>());
            container.Register(Component.For<IKegDataService>().ImplementedBy<DefaultKegDataService>());
        }
    }
}