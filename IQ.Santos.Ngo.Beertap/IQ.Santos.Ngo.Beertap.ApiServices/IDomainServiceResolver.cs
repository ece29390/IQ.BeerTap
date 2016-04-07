using System;
using IQ.Santos.Ngo.Beertap.Services;

namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    public interface IDomainServiceResolver
    {
        IDomainService Resolve(Type requestedServiceType);

        TService Resolve<TService>()
            where TService : IDomainService;
    }
}

namespace IQ.Santos.Ngo.Beertap.Services
{
    /// <summary> 
    /// Represents a specific domain service / repository used in IApiApplicationService implementations 
    /// </summary> 
    public interface IDomainService
    {
    }
}
