using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace IQ.Santos.Ngo.Beertap.ApiServices.Security
{

    public class BeertapApiUser : ApiUser<UserAuthData>
    {
        public BeertapApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class BeertapUserFactory : ApiUserFactory<BeertapApiUser, UserAuthData>
    {
        public BeertapUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override BeertapApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new BeertapApiUser("Beertap user", auth);
        }
    }

}
