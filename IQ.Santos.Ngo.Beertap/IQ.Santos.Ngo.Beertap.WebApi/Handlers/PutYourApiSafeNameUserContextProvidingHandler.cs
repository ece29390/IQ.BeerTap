using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQ.Santos.Ngo.Beertap.ApiServices.Security;

namespace IQ.Santos.Ngo.Beertap.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<BeertapApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<BeertapApiUser> apiUserInRequestStore)
            : base(new BeertapUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<BeertapApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<BeertapApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}